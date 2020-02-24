# Real time Telemetry Web Site
**Blazor server based website that reads telemetry from an IOT Hub**
  
# Setup IOT Hub
1. Create IOT Hub on Azure
1. Add Devices
    1. use `az iot hub device-identity create --hub-name {Hub Name ie wsufsaeHub} --device-id {device name ie acceleratorPosition}`
    1. Can get connection string from created device `az iot hub device-identity show-connection-string --hub-name {Hub Name ie wsufsaeHub} --device-id {device name ie acceleratorPosition} --output table`
1. Generating SAS key
    1. Just use VSCode as its easiest (add extension, find hub and in bottom right leaf folder click on 3 dots and click generate)



# Setup Website
1. Fix appsettings **(DO NOT DELETE CONFIG TEMPLATE)**
    1. Copy appsettings.config.json and rename as appsettings.json 
    1. Replace s_eventHubsCompatibleEndpoint with info found from running command `az iot hub show --query properties.eventHubEndpoints.events.endpoint --name {your IoT Hub name}` result
    1. Replace s_eventHubsCompatiblePath with `az iot hub show --query properties.eventHubEndpoints.events.path --name {your IoT Hub name}` result
    1. Replace s_iotHubSasKey with `az iot hub policy show --name {key name (probably service)} --query primaryKey --hub-name {your IoT Hub name}` result
    1. Replace s_iotHubSasKeyName with `{key name from above}`
1. Fix appsettings.Development **(DO NOT DELETE CONFIG TEMPLATE)**
    1. Copy appsettings.Development.config.json and rename as appsettings.Development.json
1. Run with IIS


#
