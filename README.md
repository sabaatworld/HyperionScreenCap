# HyperionScreenCap

Windows screen capture program for the [Hyperion](https://github.com/tvdzwan/hyperion) open-source Ambilight project.

The program uses Direct3D9 to capture the screen, resize it and send it to the ProtoBuffer interface of Hyperion.

## Download
[SetupHyperionScreenCap.exe](https://github.com/hanselb/HyperionScreenCap/releases/download/v2.0/SetupHyperionScreenCap.exe)

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
    <add key="hyperionServerIP" value="0.0.0.0"/> <!-- IP / hostname -->
    <add key="hyperionServerPort" value="19445"/> <!-- Protobuffer port -->
    <add key="hyperionMessagePriority" value="10"/> <!-- Lower number means higher priority -->
    <add key="hyperionMessageDuration" value="1000"/> <!-- How long will each captured screenshot stay on LEDs -->
    <add key="width"  value="64"/> <!-- Keep these values small -->
    <add key="height" value="64"/> <!-- Keep these values small -->
    <add key="captureInterval" value="5"/> <!-- Image capture interval -->
    <add key="notificationLevel" value="Info"/> <!-- Info/Error/None -->
    <add key="monitorIndex" value="0"/> <!-- 0 is the main monitor -->
    <add key="captureMethod" value="DX9"/> <!-- Can be either DX9 or DX11 -->
    <add key="dx11MaxFps" value="60"/> <!-- Maximum number of updates per second to be sent to Hyperion -->
    <add key="dx11FrameCaptureTimeout" value="2000"/> <!-- Timeout for each frame capture attempt -->
    <add key="dx11ImageScalingFactor" value="64"/> <!-- Factor by which captured image should be scaled. Can be any power of 2. -->
    <add key="dx11AdapterIndex" value="0"/> <!-- Zero based GPU index -->
    <add key="dx11MonitorIndex" value="0"/> <!-- Zero based display index -->
  </appSettings>
<startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0,Profile=Client"/></startup>
</configuration>
```
