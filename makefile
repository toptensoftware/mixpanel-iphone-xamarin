XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT=./MixPanel.xcodeproj
CONFIG=Release
MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all: MixPanel.dll

libi386.a:
	$(XBUILD) -project $(PROJECT) -target MixPanel -sdk iphonesimulator -configuration $(CONFIG) clean build
	-mv ./build/$(CONFIG)-iphonesimulator/libMixPanel.a $@

libArmv7.a:
	$(XBUILD) -project $(PROJECT) -target MixPanel -sdk iphoneos -arch armv7 -configuration $(CONFIG) clean build
	-mv ./build/$(CONFIG)-iphoneos/libMixPanel.a $@

libArmv7s.a:
	$(XBUILD) -project $(PROJECT) -target MixPanel -sdk iphoneos -arch armv7s -configuration $(CONFIG) clean build
	-mv ./build/$(CONFIG)-iphoneos/libMixPanel.a $@

libArm64.a:
	$(XBUILD) -project $(PROJECT) -target MixPanel -sdk iphoneos -arch arm64 -configuration $(CONFIG) clean build
	-mv ./build/$(CONFIG)-iphoneos/libMixPanel.a $@

./MixPanelBinding/libMixPanel.a: libi386.a libArmv7.a libArmv7s.a libArm64.a
	lipo -create -output ./MixPanelBinding/libMixPanel.a $^

./build/MPNotification.storyboardc:
	ibtool --output-format binary1 --compile $@ ./mixpanel-iphone/Mixpanel/MPNotification.storyboard

./build/MPSurvey.storyboardc:
	ibtool --output-format binary1 --compile $@ ./mixpanel-iphone/Mixpanel/MPSurvey.storyboard

MixPanel.dll: ./MixPanelBinding/libMixPanel.a ./build/MPNotification.storyboardc ./build/MPSurvey.storyboardc
	$(MONOXBUILD) /p:Configuration=Release MixPanelBinding/MixPanel.csproj
	cp MixPanelBinding/bin/Release/MixPanel.dll .

clean:
	rm -f MixPanel.dll
	rm -rf ./build/MPNotification.storyboardc
	rm -rf ./build/MPSurvey.storyboardc
	rm -f lib*.a
