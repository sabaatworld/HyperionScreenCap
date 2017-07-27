# HyperionScreenCap

Windows screen capture program for the [Hyperion](https://github.com/tvdzwan/hyperion) open-source Ambilight project.

The program uses Direct3D9 to capture the screen, resize it and send it to the ProtoBuffer interface of Hyperion.

## Download
[SetupHyperionScreenCap.exe](https://github.com/hanselb/HyperionScreenCap/releases/download/v1.4/SetupHyperionScreenCap.exe)

## Dependencies

[DirectX End-User Runtime](https://www.microsoft.com/en-us/download/details.aspx?displaylang=en&id=35)

[Visual C++ Redistributable for Visual Studio 2012](https://www.microsoft.com/en-us/download/details.aspx?id=30679)

[Microsoft Visual C++ 2010 Service Pack 1](https://www.microsoft.com/en-us/download/details.aspx?id=26999)

[Microsoft Visual C++ 2008 Service Pack 1](https://www.microsoft.com/en-us/download/details.aspx?id=26368)


## Configuration

Comes with setup form which is accessible via system tray, however manual config edit is also possible and below is an example HyperionScreenCap.exe.config :

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="hyperionServerIP" value="10.1.2.10"/>
    <add key="hyperionServerPort" value="19445"/>
    <add key="hyperionMessagePriority" value="10"/> <!-- Lower number means higher priority -->
    <add key="hyperionMessageDuration" value="1000"/> <!-- How long will each captured screenshot stay on LEDs -->
    <add key="width"  value="64"/> <!-- Keep these values small -->
    <add key="height" value="64"/> <!-- Keep these values small -->
    <add key="captureInterval" value="60"/>
    <add key="notificationLevel" value="None"/>
    <add key="monitorIndex" value="0"/> <!-- 0 is the main monitor -->
    <add key="apiEnabled" value="False" />
    <add key="apiExcludedTimesEnabled" value="False" />
    <add key="apiExcludeTimeStart" value="23-7-2017 08:00:00" />
    <add key="apiExcludeTimeEnd" value="23-7-2017 20:00:00" />
    <add key="captureOnStartup" value="False" />
  </appSettings>
<startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0,Profile=Client"/></startup>
</configuration>
```
