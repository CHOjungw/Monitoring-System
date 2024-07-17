using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace MonitoringSystem
{
    public class PIDController
    {
        private double _kp, _ki, _kd;
        private double _previousError, _integral;
        private double _integralMax = 80;
        public PIDController(double kp,double ki, double kd) 
        {
            _kp = kp;
            _ki = ki;
            _kd = kd;
            _previousError = 0;
            _integral = 0;
        }
        public double Compute(double setpoint, double actual, double deltaTime) 
        {
            double error = setpoint - actual;
            _integral += error * deltaTime;
            _integral = Math.Max(-_integralMax, Math.Min(_integralMax,_integral));
            double derivative = (error - _previousError) / deltaTime;
            double output = _kp * error + _ki * _integral + _kd * derivative;
            _previousError = error;
            return Math.Max(-1, Math.Min(1, output));
        }
    }
}
