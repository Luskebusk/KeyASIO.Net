﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace KeyAsio.Gui.Converters;

internal class Multi_LatencySampleRate2LatencyConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values is [int playbackLatency, int sampleRate])
        {
            var latency = 1000d / sampleRate * playbackLatency;
            return latency;
        }

        return double.NaN;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}