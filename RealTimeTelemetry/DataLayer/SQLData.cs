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
            return _context.AcceleratorPosition.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public IEnumerable<AcceleratorPosition> GetAllAcceleratorPosition()
        {
            return _context.AcceleratorPosition.AsNoTracking();
        }

        public IEnumerable<BrakeActive> GetAllBrakeActive()
        {
            return _context.BrakeActive.AsNoTracking();
        }

        public IEnumerable<VehicleRPM> GetAllVehicleRPM()
        {
            return _context.VehicleRPM.AsNoTracking();
        }

        public IEnumerable<GearActive> GetAllGearActive()
        {
            return _context.GearActive.AsNoTracking();
        }

        public IEnumerable<SteeringPosition> GetAllSteeringPosition()
        {
            return _context.SteeringPosition.AsNoTracking();
        }

        public IEnumerable<VehicleSpeed> GetAllVehicleSpeed()
        {
            return _context.VehicleSpeed.AsNoTracking();
        }

        public IEnumerable<WheelSpeed> GetAllWheelSpeed()
        {
            return _context.WheelSpeed.AsNoTracking();
        }

        public IEnumerable<BrakeActive> GetBrakeActiveBetweenTimes(DateTime start, DateTime end)
        {
            return _context.BrakeActive.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public IEnumerable<VehicleRPM> GetVehicleRPMBetweenTimes(DateTime start, DateTime end)
        {
            return _context.VehicleRPM.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public IEnumerable<GearActive> GetGearActiveBetweenTimes(DateTime start, DateTime end)
        {
            return _context.GearActive.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public AcceleratorPosition GetMostRecentAccelatorPosition()
        {
            return _context.AcceleratorPosition.AsNoTracking().FirstOrDefault();
        }

        public BrakeActive GetMostRecentBrakeActive()
        {
            return _context.BrakeActive.AsNoTracking().FirstOrDefault();
        }

        public VehicleRPM GetMostRecentVehicleRPM()
        {
            return _context.VehicleRPM.AsNoTracking().FirstOrDefault();
        }

        public GearActive GetMostRecentGearActive()
        {
            return _context.GearActive.AsNoTracking().FirstOrDefault();
        }

        public SteeringPosition GetMostRecentSteeringPosition()
        {
            return _context.SteeringPosition.AsNoTracking().FirstOrDefault();
        }

        public VehicleSpeed GetMostRecentVehicleSpeed()
        {
            return _context.VehicleSpeed.AsNoTracking().FirstOrDefault();
        }

        public WheelSpeed GetMostRecentWheelSpeed()
        {
            return _context.WheelSpeed.AsNoTracking().FirstOrDefault();
        }

        public IEnumerable<SteeringPosition> GetSteeringPositionBetweenTimes(DateTime start, DateTime end)
        {
            return _context.SteeringPosition.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public IEnumerable<VehicleSpeed> GetVehicleSpeedBetweenTimes(DateTime start, DateTime end)
        {
            return _context.VehicleSpeed.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public IEnumerable<WheelSpeed> GetWheelSpeedBetweenTimes(DateTime start, DateTime end)
        {
            return _context.WheelSpeed.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public AcceleratorPosition InsertAcceleratorPosition(AcceleratorPosition acceleratorPosition)
        {
            _context.AcceleratorPosition.Add(acceleratorPosition);
            _context.SaveChanges();
            _context.Entry(acceleratorPosition).State = EntityState.Detached;
            return acceleratorPosition;
        }

        public List<AcceleratorPosition> InsertAcceleratorPosition(List<AcceleratorPosition> acceleratorPosition)
        {
            _context.AcceleratorPosition.AddRange(acceleratorPosition);
            _context.SaveChanges();
            _context.Entry(acceleratorPosition).State = EntityState.Detached;
            return acceleratorPosition;
        }

        public BrakeActive InsertBrakeActive(BrakeActive brakeActive)
        {
            _context.BrakeActive.Add(brakeActive);
            _context.SaveChanges();
            _context.Entry(brakeActive).State = EntityState.Detached;
            return brakeActive;
        }

        public List<BrakeActive> InsertBrakeActive(List<BrakeActive> brakeActive)
        {
            _context.BrakeActive.AddRange(brakeActive);
            _context.SaveChanges();
            _context.Entry(brakeActive).State = EntityState.Detached;
            return brakeActive;
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
            _context.SaveChanges();
            _context.Entry(gearActive).State = EntityState.Detached;
            return gearActive;
        }

        public List<GearActive> InsertGearActive(List<GearActive> gearActive)
        {
            _context.GearActive.AddRange(gearActive);
            _context.SaveChanges();
            _context.Entry(gearActive).State = EntityState.Detached;
            return gearActive;
        }

        public SteeringPosition InsertSteeringPosition(SteeringPosition steeringPosition)
        {
            _context.SteeringPosition.Add(steeringPosition);
            _context.SaveChanges();
            _context.Entry(steeringPosition).State = EntityState.Detached;
            return steeringPosition;
        }

        public List<SteeringPosition> InsertSteeringPosition(List<SteeringPosition> steeringPosition)
        {
            _context.SteeringPosition.AddRange(steeringPosition);
            _context.SaveChanges();
            _context.Entry(steeringPosition).State = EntityState.Detached;
            return steeringPosition;
        }

        public VehicleSpeed InsertVehicleSpeed(VehicleSpeed vehicleSpeed)
        {
            _context.VehicleSpeed.Add(vehicleSpeed);
            _context.SaveChanges();
            _context.Entry(vehicleSpeed).State = EntityState.Detached;
            return vehicleSpeed;
        }

        public List<VehicleSpeed> InsertVehicleSpeed(List<VehicleSpeed> vehicleSpeed)
        {
            _context.VehicleSpeed.AddRange(vehicleSpeed);
            _context.SaveChanges();
            _context.Entry(vehicleSpeed).State = EntityState.Detached;
            return vehicleSpeed;
        }

        public WheelSpeed InsertWheelSpeed(WheelSpeed wheelSpeed)
        {
            _context.WheelSpeed.Add(wheelSpeed);
            _context.Entry(wheelSpeed).State = EntityState.Detached;
            _context.SaveChanges();
            return wheelSpeed;
        }

        public List<WheelSpeed> InsertWheelSpeed(List<WheelSpeed> wheelSpeed)
        {
            _context.WheelSpeed.AddRange(wheelSpeed);
            _context.Entry(wheelSpeed).State = EntityState.Detached;
            _context.SaveChanges();
            return wheelSpeed;
        }

        public EngineTemperature GetMostRecentEngineTemperature()
        {
            return _context.EngineTemperature.AsNoTracking().FirstOrDefault();

        }

        public IEnumerable<EngineTemperature> GetAllEngineTemperature()
        {
            return _context.EngineTemperature.AsNoTracking();

        }

        public IEnumerable<EngineTemperature> GetEngineTemperatureBetweenTimes(DateTime start, DateTime end)
        {
            return _context.EngineTemperature.AsNoTracking().Where(u => u.TimeStamp >= start && u.TimeStamp <= end);
        }

        public EngineTemperature InsertEngineTemperature(EngineTemperature engineTemperature)
        {
            _context.EngineTemperature.Add(engineTemperature);
            _context.SaveChanges();
            _context.Entry(engineTemperature).State = EntityState.Detached;
            return engineTemperature;
        }

        public List<EngineTemperature> InsertEngineTemperature(List<EngineTemperature> engineTemperature)
        {
            _context.EngineTemperature.AddRange(engineTemperature);
            _context.SaveChanges();
            _context.Entry(engineTemperature).State = EntityState.Detached;
            return engineTemperature;
        }
    }
}
