# HyperionScreenCap
Windows screen capture program for the [Hyperion](https://github.com/tvdzwan/hyperion) open-source Ambilight project.

Download latest realease from [here](https://github.com/djhansel/HyperionScreenCap/releases/latest).

Setup is done by modifying the HyperionScreenCap.exe.config file.

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="hyperionServerIP" value="192.168.1.171"/>
    <add key="hyperionServerJsonPort" value="19444"/> <!-- Hyperion JSON port -->
    <add key="hyperionMessagePriority" value="10"/> 
    <add key="hyperionMessageDuration" value="1000"/>
    <add key="width" value="114"/> <!-- Keep these values small -->
    <add key="height" value="64"/> <!-- Keep these values small -->
    <add key="captureInterval" value="50"/>
  </appSettings>
<startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0,Profile=Client"/></startup></configuration>
```
