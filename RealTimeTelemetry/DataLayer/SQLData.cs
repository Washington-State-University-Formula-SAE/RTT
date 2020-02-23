using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class SQLData : IDataReadContext, IDataWriteContext
    {
        private TelematryContext _context;
        public SQLData()
        {
            _context = new TelematryContext();
        }

        public IEnumerable<AcceleratorPosition> GetAcceleratorPositionBetweenTimes(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AcceleratorPosition> GetAllAcceleratorPosition()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BrakeActive> GetAllBrakeActive()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleRPM> GetAllVehicleRPM()
        {
            return _context.VehicleRPM.AsNoTracking();
        }

        public IEnumerable<GearActive> GetAllGearActive()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SteeringPosition> GetAllSteeringPosition()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleSpeed> GetAllVehicleSpeed()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WheelSpeed> GetAllWheelSpeed()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BrakeActive> GetBrakeActiveBetweenTimes(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleRPM> GetVehicleRPMBetweenTimes(DateTime start, DateTime end)
        {
            return _context.VehicleRPM.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public IEnumerable<GearActive> GetGearActiveBetweenTimes(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public AcceleratorPosition GetMostRecentAccelatorPosition()
        {
            throw new NotImplementedException();
        }

        public BrakeActive GetMostRecentBrakeActive()
        {
            throw new NotImplementedException();
        }

        public VehicleRPM GetMostRecentVehicleRPM()
        {
            return _context.VehicleRPM.AsNoTracking().FirstOrDefault();
        }

        public GearActive GetMostRecentGearActive()
        {
            throw new NotImplementedException();
        }

        public SteeringPosition GetMostRecentSteeringPosition()
        {
            throw new NotImplementedException();
        }

        public VehicleSpeed GetMostRecentVehicleSpeed()
        {
            throw new NotImplementedException();
        }

        public WheelSpeed GetMostRecentWheelSpeed()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SteeringPosition> GetSteeringPositionBetweenTimes(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleSpeed> GetVehicleSpeedBetweenTimes(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WheelSpeed> GetWheelSpeedBetweenTimes(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public AcceleratorPosition InsertAcceleratorPosition(AcceleratorPosition acceleratorPosition)
        {
            _context.AcceleratorPosition.Add(acceleratorPosition);
            return acceleratorPosition;
        }

        public List<AcceleratorPosition> InsertAcceleratorPosition(List<AcceleratorPosition> acceleratorPosition)
        {
            _context.AcceleratorPosition.AddRange(acceleratorPosition);
            return acceleratorPosition;
        }

        public BrakeActive InsertBrakeActive(BrakeActive brakeActive)
        {
            _context.BrakeActive.Add(brakeActive);
            return brakeActive;
        }

        public List<BrakeActive> InsertBrakeActive(List<BrakeActive> brakeActive)
        {
            throw new NotImplementedException();
        }

        public VehicleRPM InsertVehicleRPM(VehicleRPM VehicleRPM)
        {
            _context.VehicleRPM.Add(VehicleRPM);
            _context.SaveChanges();
            _context.Entry(VehicleRPM).State = EntityState.Detached;
            return VehicleRPM;
        }

        public List<VehicleRPM> InsertVehicleRPM(List<VehicleRPM> VehicleRPMs)
        {
            _context.VehicleRPM.AddRange(VehicleRPMs);
            _context.SaveChanges();
            _context.Entry(VehicleRPMs).State = EntityState.Detached;
            return VehicleRPMs;
        }

        public GearActive InsertGearActive(GearActive gearActive)
        {
            _context.GearActive.Add(gearActive);
            return gearActive;
        }

        public List<GearActive> InsertGearActive(List<GearActive> gearActive)
        {
            throw new NotImplementedException();
        }

        public SteeringPosition InsertSteeringPosition(SteeringPosition steeringPosition)
        {
            _context.SteeringPosition.Add(steeringPosition);
            return steeringPosition;
        }

        public List<SteeringPosition> InsertSteeringPosition(List<SteeringPosition> steeringPosition)
        {
            throw new NotImplementedException();
        }

        public VehicleSpeed InsertVehicleSpeed(VehicleSpeed vehicleSpeed)
        {
            _context.VehicleSpeed.Add(vehicleSpeed);
            return vehicleSpeed;
        }

        public List<VehicleSpeed> InsertVehicleSpeed(List<VehicleSpeed> vehicleSpeed)
        {
            throw new NotImplementedException();
        }

        public WheelSpeed InsertWheelSpeed(WheelSpeed wheelSpeed)
        {
            _context.WheelSpeed.Add(wheelSpeed);
            return wheelSpeed;
        }

        public List<WheelSpeed> InsertWheelSpeed(List<WheelSpeed> wheelSpeed)
        {
            throw new NotImplementedException();
        }
    }
}
