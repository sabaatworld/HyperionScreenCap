# HyperionScreenCap

Windows screen capture program for the [Hyperion](https://github.com/tvdzwan/hyperion) open-source Ambilight project.

The program uses Direct3D9 to capture the screen, resize it and send it to the Proto/JSON interface of Hyperion.

## Download
Portable zip: [HyperionScreenCap.zip](https://github.com/djhansel/HyperionScreenCap/releases/download/v1.2/HyperionScreenCap.zip)

Installer (auto installs dependencies): [SetupHyperionScreenCap.exe](https://github.com/djhansel/HyperionScreenCap/releases/download/v1.2/SetupHyperionScreenCap.exe)

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
    <add key="hyperionServerIP" value="192.168.1.171"/>
    <add key="hyperionServerJsonPort" value="19444"/>
    <add key="hyperionServerProtoPort" value="19445"/>
    <add key="protocol" value="proto"/> <!-- Which Hyperion protocol to use (json / proto) -->
    <add key="hyperionMessagePriority" value="10"/> <!-- Lower number means higher priority -->
    <add key="hyperionMessageDuration" value="1000"/> <!-- How long will each captured screenshot stay on LEDs -->
    <add key="width" value="114"/> <!-- Keep these values small -->
    <add key="height" value="64"/> <!-- Keep these values small -->
    <add key="captureInterval" value="50"/>
    <add key="notificationLevel" value="info"/>
    <add key="monitorIndex" value="0"/> <!-- 0 is the main monitor -->
  </appSettings>
<startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0,Profile=Client"/></startup>
</configuration>

```
