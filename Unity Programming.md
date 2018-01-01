# Unity Programming Notes

## Unity API

## Version Control

## Building & Deploying

### iOS

To build for iOS (iPhone and iPads - the tvOS is a separate target.

Getting prepared:
1. Install XCode.
1. Launch XCode.
1. Add your Apple ID (**XCode > Preferencs** on the **Accounts** tab), if you have a GitHub
account you may want to add it as well.
1. Connect the iOS device that you'll be using for testing - iTunes
will launch (launch it if it does not) and guide you through the
process of setting it up to work with XCode.

Setting up to build for an iOS target:

In Unity:
1. Open the scene(s) that are used in your game - add as many panes
as you need to have them all open.
1. From **File > Build Settings…**
1. Choose the iOS target.
1. Click on the Add Open Scenes button.

In XCode:
1. Click on the play button.
1. Your app will build.
1. Approve **codesign** access to your Keychain.

On the iOS target device:
1. You should see a Unity icon for you app.
1. When you launch an app for the first time you will receive
a notification that it comes from an Untrusted Developer with
instructions to allow them in settings. To approve launch the
Settingo app and go to
**General > Profiles & Device Management**
1. There should be a Developer App profile that matches your
email - approve it to allow your apps to run on the device.
1. Tap the Unity icon again to launch your app.

### Android

### WebGL