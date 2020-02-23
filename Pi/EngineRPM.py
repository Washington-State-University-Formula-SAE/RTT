from MQTTDevice import MQTTDevice
class EngineRPM(MQTTDevice):
    def __init__(self):
        super(EngineRPM, self).__init__("EngineRPM")
        self.RPM = None
    def SendData(self, data):
        ## parse string...
        rpm = None #Get rpm from string....
        scrubbed = data #.......
        self.RPM = scrubbed
        self._SendMessage(str(rpm))