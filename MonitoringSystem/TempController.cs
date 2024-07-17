using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MonitoringSystem
{
    public class TempController
    {
        private PIDController _pidController;
        private double _currentTemperature;
        public readonly Form1 _form1;
        public TempController(Form1 form1,double kp, double ki, double kd)
        {
            _pidController = new PIDController(kp, ki, kd); 
            _form1 = form1;
        }
        public int TimerElapsed(double setvalue)
        {
            double deltaTime = 1;
            _currentTemperature = ReadTemperatureSensor();

            double pidOutput = _pidController.Compute(setvalue, _currentTemperature, deltaTime);
            return setPWM(pidOutput);
        }

        private double ReadTemperatureSensor()
        {            
            return _form1._equipData.hv;
        }
        public int setPWM(double value)
        {
            return (int)(value * 30);
        }
    }
}
