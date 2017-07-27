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

Setup is done by modifying the HyperionScreenCap.exe.config file.

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="hyperionServerIP" value="10.1.2.100" />
    <add key="hyperionServerPort" value="19445" />
    <add key="hyperionMessagePriority" value="100" />
    <add key="hyperionServerIP2" value="0.0.0.0" />
    <add key="hyperionServerPort2" value="19445" />
    <add key="hyperionMessagePriority2" value="100" />
    <add key="hyperionMessageDuration" value="1000" />
    <add key="HyperionServerIndex" value="1" />
    <add key="width" value="64" />
    <add key="height" value="64" />
    <add key="captureInterval" value="0" />
    <add key="notificationLevel" value="Error" />
    <add key="monitorIndex" value="1" />
    <add key="reconnectInterval" value="5000" />
    <add key="apiPort" value="29445" />
    <add key="apiEnabled" value="False" />
    <add key="apiExcludedTimesEnabled" value="False" />
    <add key="apiExcludeTimeStart" value="27-7-2017 12:00:00" />
    <add key="apiExcludeTimeEnd" value="27-7-2017 17:00:00" />
    <add key="captureOnStartup" value="False" />
  </appSettings>
<startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0,Profile=Client"/></startup>
</configuration>
```
