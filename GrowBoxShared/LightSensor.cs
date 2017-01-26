﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowBoxShared
{
    class LightSensor
    {
        private int _ch;
        private double _voltSensore;
        private DigitalConverterMCP3208 _adc;

        public LightSensor(DigitalConverterMCP3208 Adc, int ch, double voltSensore = 3.3)
        {
            _ch = ch;
            _voltSensore = voltSensore;
            _adc = Adc;
        }

        public double Read()
        {
            double a = 3310.333;
            double b = 3.276211;
            double c = 0.393569;
            double d = 36.96403;

            double lux = d + ((a - d) / (1 + Math.Pow((_adc.ReadVolt(_ch, _voltSensore) / c), b)));

            if (lux < 41) lux = 0; //Scala Lux X 10 penombra o buio non significativi

            return (lux);
        }
    }
}
