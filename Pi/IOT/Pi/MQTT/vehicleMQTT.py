
from MQTT.MQTTDevice import MQTTDevice

class vehicleRPM(MQTTDevice):
    def __init__(self):
        super(vehicleRPM, self).__init__("vehicleRPM")
        self.RPM = None
    def SendData(self, data):
        self.RPM = data
        self._SendMessage(str(self.RPM))

class vehicleSpeed(MQTTDevice):
    def __init__(self):
        super(vehicleSpeed, self).__init__("vehicleSpeed")
        self.speed = None
    def SendData(self, data):
        self.speed = data
        self._SendMessage(str(self.speed))
        
class acceleratorPosition(MQTTDevice):
    def __init__(self):
        super(acceleratorPosition, self).__init__("acceleratorPosition")
        self.position = None
    def SendData(self, data):
        self.position = data
        self._SendMessage(str(self.position))

class brakeActive(MQTTDevice):
    def __init__(self):
        super(brakeActive, self).__init__("brakeActive")
        self.active = None
    def SendData(self, data):
        self.active = data
        self._SendMessage(str(self.active))

class wheelSpeed(MQTTDevice):
    def __init__(self):
        super(wheelSpeed, self).__init__("wheelSpeed")
        self.data1 = None
        self.data2 = None
        self.data3 = None
        self.data4 = None
    def SendData(self, data1, data2, data3, data4):
        self.data1 = data1
        self.data2 = data2
        self.data3 = data3
        self.data4 = data4
        self._SendMessage(str(self.data1+','+self.data2+','+data3+','+data4))

class steeringPosition(MQTTDevice):
    def __init__(self):
        super(steeringPosition, self).__init__("steeringPosition")
        self.position = None
    def SendData(self, data):
        self.position = data
        self._SendMessage(str(self.position))

class vehicleGearActive(MQTTDevice):
    def __init__(self):
        super(vehicleGearActive, self).__init__("vehicleGearActive")
        self.gearActive = None
    def SendData(self, data):
        self.gearActive = data
        self._SendMessage(str(self.gearActive))
