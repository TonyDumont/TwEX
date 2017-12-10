using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TwEX_API.Market
{
    public class TradingView
    {
        #region Properties
        public static String thisClassName = "TradingView";
        #endregion Properties

        #region DataModels
        #region DATAMODELS_Enums
        public enum TradingViewChartStyle : int
        {
            [Description("Bars")]
            Bars = 0,
            [Description("Candles")]
            Candles = 1,
            [Description("Line")]
            Line = 2,
            [Description("Area")]
            Area = 3,
            [Description("Renko")]
            Renko = 4,
            [Description("Kagi")]
            Kagi = 5,
            [Description("Point and Figure")]
            Point_and_Figure = 6,
            [Description("Line Break")]
            Line_Break = 7,
            [Description("Heikin Ashi")]
            Heikin_Ashi = 8,
            [Description("Hollow Candles")]
            Hollow_Candles = 9
            
            
        }
        public enum TradingViewChartInterval
        {
            [Description("1 Minute")]
            Minute_1,
            [Description("3 Minutes")]
            Minute_3,
            [Description("5 Minutes")]
            Minute_5,
            [Description("15 Minutes")]
            Minute_15,
            [Description("30 Minutes")]
            Minute_30,
            [Description("1 Hour")]
            Minute_60,
            [Description("2 Hours")]
            Minute_120,
            [Description("3 Hour")]
            Minute_180,
            [Description("4 Hours")]
            Minute_240,
            [Description("1 Day")]
            Day_D,
            [Description("1 Week")]
            Week_W
        }
        public enum TradingViewColorTheme
        {
            Light,
            Dark
        }
        public enum TradingViewCryptoExchange // removed '_' and '.' from names 
        {
            Bitfinex,
            bitFlyer,
            BitMEX,
            Bitso,
            Bitstamp,
            Bittrex,
            BTCChina,
            BTCYou,
            bxinth,
            CEXIO,
            Coinbase,
            Coinfloor,
            FoxBit,
            Gocio,
            HitBTC,
            Huobi,
            itBit,
            KORBIT,
            Kraken,
            Mercado,
            Okcoin,
            OKEX,
            Poloniex,
            TheRockTrading,
            Xcoin
        }
        public enum TradingViewIndicator
        {
            [Description("Accumulation/Distribution")]
            ACCD,

            [Description("ADR")]
            studyADR,

            [Description("Aroon")]
            AROON,

            [Description("Average True Range")]
            ATR,

            [Description("Awesome Oscillator")]
            AwesomeOscillator,

            [Description("Bollinger Bands")]
            BB,

            [Description("Bollinger Bands %B")]
            BollingerBandsR,

            [Description("Bollinger Bands Width")]
            BollingerBandsWidth,

            [Description("Chaikin Money Flow")]
            CMF,

            [Description("Chaikin Oscillator")]
            ChaikinOscillator,

            [Description("Chande Momentum Oscillator")]
            chandeMO,

            [Description("Choppiness Index")]
            ChoppinessIndex,

            [Description("Commodity Channel Index")]
            CCI,

            [Description("ConnorsRSI")]
            CRSI,

            [Description("Correlation Coefficient")]
            CorrelationCoefficient,

            [Description("Detrended Price Oscillator")]
            DetrendedPriceOscillator,

            [Description("Directional Movement")]
            DM,

            [Description("Donchian Channels")]
            DONCH,

            [Description("Double EMA")]
            DoubleEMA,

            [Description("Ease Of Movement")]
            EaseOfMovement,

            [Description("Elder's Force Index")]
            EFI,

            [Description("Envelope")]
            ENV,

            [Description("Fisher Transform")]
            FisherTransform,

            [Description("Historical Volatility")]
            HV,

            [Description("Hull Moving Average")]
            hullMA,

            [Description("Ichimoku Cloud")]
            IchimokuCloud,

            [Description("Keltner Channels")]
            KLTNR,

            [Description("Know Sure Thing")]
            KST,

            [Description("Linear Regression")]
            LinearRegression,

            [Description("MACD")]
            MACD,

            [Description("Momentum")]
            MOM,

            [Description("Money Flow")]
            MF,

            [Description("Moon Phases")]
            MoonPhases,

            [Description("Moving Average")]
            MASimple,

            [Description("Moving Average Exponential")]
            MAExp,

            [Description("Moving Average Weighted")]
            MAWeighted,

            [Description("On Balance Volume")]
            OBV,

            [Description("Parabolic SAR")]
            PSAR,

            [Description("Pivots Points High Low")]
            PivotPointsHighLow,

            [Description("Pivot Points Standard")]
            PivotPointsStandard,

            [Description("Price Oscillator")]
            PriceOsc,

            [Description("Price Volume Trend")]
            PriceVolumeTrend,

            [Description("Rate of Change")]
            ROC,

            [Description("Relative Strength Index")]
            RSI,

            [Description("Relative Vigor Index")]
            VigorIndex,

            [Description("Relative Volatility Index")]
            VolatilityIndex,

            [Description("SMI Ergodic Indicator")]
            SMIErgodicIndicator,

            [Description("SMI Ergodic Oscillator")]
            SMIErgodicOscillator,

            [Description("Stochastic")]
            Stochastic,

            [Description("Stochastic RSI")]
            StochasticRSI,

            [Description("Triple EMA")]
            TripleEMA,

            [Description("TRIX")]
            Trix,

            [Description("Ultimate Oscillator")]
            UltimateOsc,

            [Description("Volatility Stop")]
            VSTOP,

            [Description("Volume")]
            Volume,

            [Description("VWAP")]
            VWAP,

            [Description("VWMA")]
            MAVolumeWeighted,

            [Description("Williams %R")]
            WilliamR,

            [Description("Williams Alligator")]
            WilliamsAlligator,

            [Description("Williams Fractal")]
            WilliamsFractal,

            [Description("Zig Zag")]
            ZigZag
        }
        #endregion

        #region DATAMODELS_Parameters
        public class TradingViewAdvancedChartParameters
        {
            public TradingViewCryptoExchange exchange { get; set; }

            public string symbol { get; set; }
            public string market { get; set; }

            public TradingViewChartInterval interval { get; set; } = TradingViewChartInterval.Minute_15;
            public string timezone { get; set; } = "America/New_York";

            public int width { get; set; } = 980;
            public int height { get; set; } = 610;
            public Boolean autosize { get; set; }

            public TradingViewColorTheme theme { get; set; } = TradingViewColorTheme.Light;
            public TradingViewChartStyle style { get; set; } = TradingViewChartStyle.Candles;
            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW

            public string toolbarBackgroundColor { get; set; } = "#f1f3f6";
            public Boolean ShowTopToolbar { get; set; } = true;
            public Boolean ShowBottomToolbar { get; set; } = false;
            public Boolean AllowSymbolChange { get; set; } = true;
            public Boolean GetImageButton { get; set; } = true;
            public Boolean ShowDrawingToolsBar { get; set; } = false;
            public Boolean ShowIdeasOnChart { get; set; } = false;
            public Boolean ShowIdeasButton { get; set; } = false;

            public Boolean LaunchInPopupButton { get; set; } = false;
            public int popupWidth { get; set; } = 1000;
            public int popupHeight { get; set; } = 650;

            public Boolean EnablePublishing { get; set; } = false;
            public Boolean ActivateReferralProgram { get; set; } = false;
            public string referral_id { get; set; } = string.Empty;

            public Boolean ShowWatchlist { get; set; } = false;
            public Boolean ShowDetails { get; set; } = false;
            public Boolean ShowStockTwits { get; set; } = false;
            public Boolean ShowHeadlines { get; set; } = false;
            public Boolean ShowHotlist { get; set; } = false;
            public Boolean ShowCalendar { get; set; } = false;
            public Boolean ShowIndicators { get; set; } = false;

            public List<TradingViewWatchlistItem> WatchList { get; set; } = new List<TradingViewWatchlistItem>();
            public List<TradingViewIndicator> IndicatorList { get; set; } = new List<TradingViewIndicator>();
        }
        #endregion

        public class TradingViewWatchlistItem
        {
            public TradingViewCryptoExchange exchange { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }

            public string GetWatchlistString()
            {
                return exchange.ToString().ToUpper() + ":" + symbol.ToUpper() + market.ToUpper();
            }
        }

        #endregion DataModels
    }
}
