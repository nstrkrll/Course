﻿using System.Collections.Generic;
using NUnit.Framework;

namespace Polynomial.Tests
{
    public sealed class TestCasesData
    {
        static TestCasesData()
        {
            Polynomial.AppSettings.Epsilon = 0.00001;
        }

        public static IEnumerable<TestCaseData> TestCasesForEquals
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1d, 2d, 3d), new Polynomial(1d, 2d, 3d))
                    .Returns(true);
                yield return new TestCaseData(new Polynomial(0.5), new Polynomial(0.49999999))
                    .Returns(true);
                yield return new TestCaseData(new Polynomial(0, 0.1, 0.0001), new Polynomial(0, 0.1, 0.00010091))
                    .Returns(true);
                yield return new TestCaseData(new Polynomial(-10.12300013, 5.89), new Polynomial(-10.123, 5.89))
                    .Returns(true);
                yield return new TestCaseData(new Polynomial(1d, 2d, 3d), new Polynomial(1d, 2d, 3d))
                    .Returns(true);
                yield return new TestCaseData(new Polynomial(0.5), new Polynomial(0.5000021))
                    .Returns(true);
                yield return new TestCaseData(new Polynomial(0, 0.1, 0.0001), new Polynomial(0, 0.1, 0.0001))
                    .Returns(true);
                yield return new TestCaseData(new Polynomial(-10.123, 5.89), new Polynomial(-10.12300004, 5.89))
                    .Returns(true);
                yield return new TestCaseData(new Polynomial(1d, 2d, 3d), new Polynomial(1.5, 2d, 3d))
                    .Returns(false);
                yield return new TestCaseData(new Polynomial(-100.123, 5.89, double.MinValue, double.MaxValue), new Polynomial(-10.123, 5.89, double.MinValue, double.MaxValue))
                    .Returns(false);
                yield return new TestCaseData(new Polynomial(-0.123, 0.0, -0.0), new Polynomial(-0.123065, 0.0, -0.0))
                    .Returns(false);
                yield return new TestCaseData(new Polynomial(1d, 2d, 3d), null)
                    .Returns(false);
                yield return new TestCaseData(new Polynomial(-0.5, 0d, 0.5), new Polynomial(-0.5, 0.5, 0))
                    .Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForToString
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new[] { 0.0001, -0.003, 0.31, -0.00731, 0.000402, 0.000300021 }))
                    .Returns("0.000300021*x^5+0.000402*x^4-0.00731*x^3+0.31*x^2-0.003*x+0.0001");
                yield return new TestCaseData(new Polynomial(new[] { -1, 0.2, 3.313, 0.004, 0.05, 0.16 }))
                    .Returns("0.16*x^5+0.05*x^4+0.004*x^3+3.313*x^2+0.2*x-1");
                yield return new TestCaseData(new Polynomial(new[] { -1.1, 2.42, -0.0957, -2.2242, 10.0991, -14.498, -0.2046, 0.308, -0.704 }))
                    .Returns("-0.704*x^8+0.308*x^7-0.2046*x^6-14.498*x^5+10.0991*x^4-2.2242*x^3-0.0957*x^2+2.42*x-1.1");
                yield return new TestCaseData(new Polynomial(new[] { -1.1, -0.0000007, -0.0957, -2.2242, 10.0991, -14.498, -0.2046, 0.0000012, -0.704 }))
                    .Returns("-0.704*x^8-0.2046*x^6-14.498*x^5+10.0991*x^4-2.2242*x^3-0.0957*x^2-1.1");
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForGetHashCode
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1d, 2d, 3d), new Polynomial(1d, 2d, 3d));
                yield return new TestCaseData(new Polynomial(0.5), new Polynomial(0.4999999));
                yield return new TestCaseData(new Polynomial(0, 0.1, 0.0001), new Polynomial(0, 0.1, 0.000100876));
                yield return new TestCaseData(new Polynomial(-10.1230000432, 5.89), new Polynomial(-10.123, 5.89));
                yield return new TestCaseData(new Polynomial(1d, 2d, 3d), new Polynomial(1d, 2d, 3d - double.Epsilon));
                yield return new TestCaseData(new Polynomial(0, 0.1, 0.0001), new Polynomial(0, 0.1, 0.0001));
                yield return new TestCaseData(new Polynomial(-10.123, 5.89), new Polynomial(-10.123, 5.8900023));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForMultiplication
        {
            get
            {
                yield return new TestCaseData(
                    new Polynomial(1.21394, 2.001, 3.3),
                    new Polynomial(0.1, 0.002),
                    new Polynomial(0.12139, 0.20253, 0.334, 0.0066));
                yield return new TestCaseData(
                    new Polynomial(-1, 0.2, 3.313, 0.004, 0.05, 0.16),
                    new Polynomial(1.1, -2.2, 3.3, -4.4),
                    new Polynomial(-1.1, 2.42, -0.0957, -2.2242, 10.0991, -14.498, -0.2046, 0.308, -0.704));
                yield return new TestCaseData(
                    new Polynomial(-3, 0.014, 1.004),
                    new Polynomial(1, 0, 5),
                    new Polynomial(-3, 0.014, -13.996, 0.07, 5.02));
                yield return new TestCaseData(
                    new Polynomial(1.204, -2.569, 3.987, 4.879, -0.896, 9),
                    new Polynomial(1, -2, -3, 4),
                    new Polynomial(1.204, -4.977, 5.513, 9.428, -32.891, 12.103, 4.204, -30.584, 36));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForSubtraction
        {
            get
            {
                yield return new TestCaseData(
                    new Polynomial(0.1, 0.002),
                    new Polynomial(1.21394, 2.001, 3.3),
                    new Polynomial(-1.11394, -1.999, -3.3));
                yield return new TestCaseData(
                    new Polynomial(1.21394, 2.001, 3.3),
                    new Polynomial(0.1, 0.002),
                    new Polynomial(1.11394, 1.999, 3.3));
                yield return new TestCaseData(
                    new Polynomial(-1, 0.2, 3.313, 0.004, 0.05, 0.16),
                    new Polynomial(1.1, -2.2, 3.3, -4.4),
                    new Polynomial(-2.1, 2.4, 0.013, 4.404, 0.05, 0.16));
                yield return new TestCaseData(
                    new Polynomial(-3, 0.014, 1.004, 0),
                    new Polynomial(1, -0.0d, 5),
                    new Polynomial(-4, 0.014, -3.996, 0));
                yield return new TestCaseData(
                    new Polynomial(1.204, -2.569, 3.987, 4.879, -0.896, 9),
                    new Polynomial(1, -2, -3, 4),
                    new Polynomial(0.204, -0.569, 6.987, 0.879, -0.896, 9));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForAddition
        {
            get
            {
                yield return new TestCaseData(
                    new Polynomial(1.21394, 2.001, 3.3),
                    new Polynomial(0.1, 0.002),
                    new Polynomial(1.31394, 2.003, 3.3));
                yield return new TestCaseData(
                    new Polynomial(-1, 0.2, 3.313, 0.004, 0.05, 0.16),
                    new Polynomial(1.1, -2.2, 3.3, -4.4),
                    new Polynomial(0.1, -2, 6.613, -4.396, 0.05, 0.16));
                yield return new TestCaseData(
                    new Polynomial(-3, 0.014, 1.004, 0),
                    new Polynomial(1, -0.0d, 5),
                    new Polynomial(-2, 0.014, 6.004, 0));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForIndexer
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1.21394, 2.001, 3.3), 1).Returns(2.001);
                yield return new TestCaseData(new Polynomial(-1, 0.2, 3.313, 0.004, 0.05, 0.16), 2).Returns(3.313);
                yield return new TestCaseData(new Polynomial(-1, 0.2, 3.313, 0.004, 0.05, 0.16), 5).Returns(0.16);
                yield return new TestCaseData(new Polynomial(-3, 0.014, 1.004, 0), 0).Returns(-3);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForIndexerException
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1.21394, 2.001, 3.3), -1);
                yield return new TestCaseData(new Polynomial(-1, 0.2, 3.313, 0.004, 0.05, 0.16), -2);
                yield return new TestCaseData(new Polynomial(-1, 0.2, 3.313, 0.004, 0.05, 0.16), 9);
                yield return new TestCaseData(new Polynomial(-3, 0.014, 1.004, 9), 12);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForOperationException
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1.21394, 2.001, 3.3), null);
                yield return new TestCaseData(null, new Polynomial(-1, 0.2, 3.313, 0.004, 0.05, 0.16));
                yield return new TestCaseData(null, null);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForCalculateValue
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1.21394, 2.001, 3.3), -0.5, 1.03844);
                yield return new TestCaseData(new Polynomial(-1, 0.2, 3.313, 0.004, 0.05, 0.16), -0.5, -0.274125);
                yield return new TestCaseData(new Polynomial(3, 0.014, 1.004, 0), -0.5, 3.244);
                yield return new TestCaseData(new Polynomial(1.21394, 2.001, 3.3), 1.5, 11.64044);
                yield return new TestCaseData(new Polynomial(-1, 0.2, 3.313, 0.004, 0.05, 0.16), 1.5, 8.235875);
                yield return new TestCaseData(new Polynomial(3, 0.014, 1.004, 0), 1.5, 5.28);
            }
        }
    }
}
