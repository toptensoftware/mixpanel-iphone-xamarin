XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
TARGET=MixPanel
PROJECT=$(PROJECT_ROOT)/$(TARGET).xcodeproj
CONFIG=Release

all: lib$(TARGET).a $(PROJECT_ROOT)/build/MPNotification.storyboardc $(PROJECT_ROOT)/build/MPSurvey.storyboardc

libi386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration $(CONFIG) clean build
	-mv $(PROJECT_ROOT)/build/$(CONFIG)-iphonesimulator/lib$(TARGET).a $@

libArmv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration $(CONFIG) clean build
	-mv $(PROJECT_ROOT)/build/$(CONFIG)-iphoneos/lib$(TARGET).a $@

libArmv7s.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration $(CONFIG) clean build
	-mv $(PROJECT_ROOT)/build/$(CONFIG)-iphoneos/lib$(TARGET).a $@

libArm64.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration $(CONFIG) clean build
	-mv $(PROJECT_ROOT)/build/$(CONFIG)-iphoneos/lib$(TARGET).a $@

lib$(TARGET).a: libi386.a libArmv7.a libArmv7s.a libArm64.a
	lipo -create -output lib$(TARGET).a $^

$(PROJECT_ROOT)/build/MPNotification.storyboardc:
	ibtool --output-format binary1 --compile $@ $(PROJECT_ROOT)/../MixPanel/MPNotification.storyboard

$(PROJECT_ROOT)/build/MPSurvey.storyboardc:
	ibtool --output-format binary1 --compile $@ $(PROJECT_ROOT)/../MixPanel/MPSurvey.storyboard

clean:
	rm -rf $(PROJECT_ROOT)/build/MPNotification.storyboardc
	rm -rf $(PROJECT_ROOT)/build/MPSurvey.storyboardc
	rm -f lib*.a
