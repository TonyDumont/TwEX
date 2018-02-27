using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TwEX_API.Market
{
    public class TradingView
    {
        #region Properties
        public static String Name = "TradingView";
        #endregion Properties

        #region Getters
        public static List<TradingViewWatchlistItem> GetWatchListBySymbol(string symbol)
        {
            List<TradingViewWatchlistItem> list = new List<TradingViewWatchlistItem>();
            
            //StringBuilder builder = new StringBuilder();
            //builder.Append("\"watchlist\": [");

            List<ExchangeManager.Exchange> exchangeList = ExchangeManager.Exchanges.Where(item => item.TradingView.Length > 0).ToList();

            //int listCount = 0;
            // loop
            if (symbol != "BTC")
            {
                // BTC
                foreach (ExchangeManager.Exchange exchange in exchangeList)
                {
                    TradingViewWatchlistItem newItem = new TradingViewWatchlistItem()
                    {
                        exchange = (TradingViewCryptoExchange)Enum.Parse(typeof(TradingViewCryptoExchange), exchange.TradingView, true),
                        symbol = symbol,
                        market = "BTC"
                    };
                    list.Add(newItem);
                    //listCount++;
                }

                //listCount = 0;
                // USD
                foreach (ExchangeManager.Exchange exchange in exchangeList)
                {
                    TradingViewWatchlistItem newItem = new TradingViewWatchlistItem()
                    {
                        exchange = (TradingViewCryptoExchange)Enum.Parse(typeof(TradingViewCryptoExchange), exchange.TradingView, true),
                        symbol = symbol,
                        market = exchange.USDSymbol
                    };
                    list.Add(newItem);
                    //listCount++;
                }

            }
            else
            {
                // JUST USD
                foreach (ExchangeManager.Exchange exchange in exchangeList)
                {
                    TradingViewWatchlistItem newItem = new TradingViewWatchlistItem()
                    {
                        exchange = (TradingViewCryptoExchange)Enum.Parse(typeof(TradingViewCryptoExchange), exchange.TradingView, true),
                        symbol = symbol,
                        market = exchange.USDSymbol
                    };
                    list.Add(newItem);
                    //listCount++;
                }
            }

            //builder.Append("],");
            //LogManager.AddDebugMessage(this.Name, "GetWatchlist", builder.ToString());
            //return builder.ToString();
            

            return list;
        }
        #endregion

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
            none,
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
        public enum TradingViewCryptocurrencyMarketDefaultColumn
        {
            overview,
            performance,
            oscillators,
            moving_averages
        }
        public enum TradingViewCryptocurrencyMarketDisplayCurrency
        {
            USD,
            BTC
        }
        public enum TradingViewCurrency
        {
            EUR,
            USD,
            JPY,
            GBP,
            CHF,
            AUD,
            CAD,
            NZD,
            CNY,
            TRY,
            SEK,
            NOK,
            DKK,
            ZAR,
            HKD,
            SGD,
            THB,
            MXN,
            IDR,
            KRW,
            PLN,
            ISK,
            KWD,
            PHP,
            MYR,
            INR,
            TWD,
            SAR,
            RUB,
            ILS
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

        public enum TradingViewExchange
        {
            [Description("USA (US Exchanges)")]
            US,

            [Description("USA (NASDAQ)")]
            NASDAQ,

            [Description("USA (NYSE)")]
            NYSE,

            [Description("USA (NYSE ARCA)")]
            AMEX,

            [Description("USA (OTC)")]
            OTC,

            [Description("Canada (TSX)")]
            TSX,

            [Description("Canada (TSXV)")]
            TSXV,

            [Description("Germany (FWB)")]
            FWB,

            [Description("Germany (XETR)")]
            XETR,

            [Description("India (BSE)")]
            BSE,

            [Description("India (NSE)")]
            NSE,

            [Description("Italy (MIL)")]
            MIL,

            [Description("Turkey (BIST)")]
            BIST,

            [Description("United Kingdom (LSE)")]
            LSE,

            [Description("United Kingdom (LSIN)")]
            LSIN
        }
        public enum TradingViewExchangeMarket
        {
            [Description("USA (NASDAQ, NYSE, ARCA, OTC)")]
            exchange_america,

            [Description("Canada (TSX, TXSV)")]
            exchange_canada,

            [Description("Germany (FWB, XETR)")]
            exchange_germany,

            [Description("India (BSE, NSE)")]
            exchange_india,

            [Description("Italy (MIL)")]
            exchange_italy,

            [Description("Turkey (BIST)")]
            exchange_turkey,

            [Description("United Kingdom (LSE, LSIN)")]
            exchange_uk,

            [Description("Forex")]
            market_forex,

            [Description("Cryptocurrencies")]
            market_crypto
        }
        public enum TradingViewStockScreenerDefaultColumn
        {
            [Description("Overview|market")]
            overview,

            [Description("Performance|market")]
            performance,

            [Description("Oscillators|market")]
            oscillators,

            [Description("Trend-Following|market")]
            moving_averages,

            [Description("Pivot Points Classic|market")]
            pivot_points_classic,

            [Description("Pivot Points Fibonacci|market")]
            pivot_points_fibonacci,

            [Description("Pivot Points Camarilla|market")]
            pivot_points_camarilla,

            [Description("Pivot Points Woodie|market")]
            pivot_points_woodie,

            [Description("Pivot Points Denmark|market")]
            pivot_points_denmark,

            [Description("Valuation|exchange")]
            valuation,

            [Description("Dividends|exchange")]
            dividends,

            [Description("Margins|exchange")]
            margins,

            [Description("Income Statement|exchange")]
            income_statement,

            [Description("Balance Sheet|exchange")]
            balance_sheet
        }
        public enum TradingViewStockScreenerDefaultScreen
        {
            // MARKETS
            [Description("Top Gainers|market")]
            top_gainers,

            [Description("Top Losers|market")]
            top_losers,

            [Description("All Time High|market")]
            ath,

            [Description("All Time Low|market")]
            atl,

            [Description("New 52 Week High|market")]
            above_52wk_high,

            [Description("New 52 Week Low|market")]
            below_52wk_low,

            [Description("New Monthly High|market")]
            monthly_high,

            [Description("New Monthly Low|market")]
            monthly_low,

            [Description("Most Volatile|market")]
            most_volatile,

            [Description("Overbought|market")]
            overbought,

            [Description("Oversold|market")]
            oversold,

            [Description("Outperforming SMA50|market")]
            outperforming_SMA50,

            [Description("Underperforming SMA50|market")]
            underperforming_SMA50,

            // EXCHANGES
            [Description("Most Capitalized|exchange")]
            most_capitalized,

            [Description("Volume Leaders|exchange")]
            volume_leaders,

            [Description("Top Volume|exchange")]
            top_volume,

            [Description("Unusual Volume|exchange")]
            unusual_volume,

            [Description("Earnings This Week|exchange")]
            earnings_this_week
        }
        
        public enum TradingViewSymbolOverviewInterval
        {
            [Description("1d")]
            day_1d,

            [Description("1m")]
            month_1m,

            [Description("3m")]
            month_3m,

            [Description("1y")]
            year_1y,

            [Description("5y")]
            year_5y,

            [Description("max")]
            max_max
        }
        
        public enum TradingViewWidgetType
        {
            /// <summary>Advanced Chart Widget is a free and powerful charting solution that easily embeds into any website. Simply adjust the settings and click Apply to see a preview, then copy the embed code and paste it into your site code. You can personalize the chart by modifying the default symbol, watchlist, adding tools for technical analysis and a lot more. You can even add news, hotlists, or an economic calendar to make the widget into an entire analytics platform.
            /// </summary>
            [Description("Advanced Real-Time Chart Widget")]
            AdvancedRealTimeChartWidget,

            /// <summary>Market Overview Widget provides a quick glance at the latest market activity across various sectors. It works great for homepages, and it can be configured to take users to a page with a larger chart on your site. Set your own instrument lists and tabs to cover what you need, adjust the timeframe for the chart or even hide the chart completely
            /// </summary>
            [Description("Market Overview Widget")]
            MarketOverviewWidget,

            /// <summary>Market Quotes Widget includes a detailed overview of global markets performance, including change value (both in absolute and percentage numbers), Open, High, Low and Close values for the selected financial instruments
            /// </summary>
            [Description("Market Quotes Widget")]
            MarketQuotesWidget,

            /// <summary>Market Movers Widget shows top 5 gaining, losing and active stocks for the day. Market Movers are updated based on current market activity, so they always show the most relevant stocks.
            /// </summary>
            [Description("Market Movers Widget")]
            MarketMoversWidget,

            /// <summary>Economic Calendar Widget shows key upcoming economic events, announcements and news. You can set up relevant economic calendar filters in a few clicks, selecting event importance and affected currencies.
            /// </summary>
            [Description("Economic Calendar Widget")]
            EconomicCalendarWidget,

            /// <summary>Ticker Widget is a horizontal quick-glance bar with instrument prices. You can display up to 15 different symbols with their latest price and daily change.
            /// </summary>
            [Description("Ticker Widget")]
            TickerWidget,

            /// <summary>Symbol Overview Widget shows latest quotes, a simple chart and key fundamental fields for a single stock. It’s in-depth, yet detailed, and it’s a great solution for web and mobile. You can add multiple tabs to cover several stocks and use a “Chart Only” mode for a simpler look.
            /// </summary>
            [Description("Symbol Overview Widget")]
            SymbolOverviewWidget,

            /// <summary>Forex Cross Rates Widget allows you to display real-time quotes of the selected currencies in comparison to the other major currencies at a glance. Select relevant currencies and generate your rates table in just a few clicks
            /// </summary>
            [Description("Forex Cross Rates Widget")]
            ForexCrossRatesWidget,

            /// <summary>Forex Heat Map Widget gives a quick overview of action in the currency markets. It lets you spot strong and weak currencies in real-time & how strong they are in relation to one another. This trading tool can help choose trading strategies, find opportunities and trade with confidence. Create a personal rates table with just a few clicks by selecting the currencies you want. Give this free tool to your users by copying the Embed code once finished with customization.
            /// </summary>
            [Description("Forex Heat Map Widget")]
            ForexHeatMapWidget,

            /// <summary>Screener widget is a powerful tool that allows to filter stocks based on fundamental data and various technical indicators. Widget allows to create custom filters and columns and lets you change display modes by selecting either a symbol list or a toolbar mode.
            /// </summary>
            [Description("Screener Widget")]
            ScreenerWidget,

            /// <summary>Cryptocurrency Market Widget is our latest tool for crypto traders and enthusiasts. This widget displays most of the available crypto assets and sorts them based on the market capitalization. The key metrics such as the closing price, total and available number of coins, traded volume and price change percentage are all available at a quick glance
            /// </summary>
            [Description("Cryptocurrency Market Widget")]
            CryptocurrencyMarketWidget,

            /// <summary>Fundamental Chart Widget is an essential free tool for business, economics and finance related websites. Fundamental data about stocks provides insights into how the company is doing beyond simple stock price information. Check our wide range of fundamentals for any symbol from many of the world’s major exchanges.
            /// </summary>
            [Description("Fundamental Chart Widget")]
            FundamentalChartWidget,
        }
        #endregion
        #region DATAMODELS_Parameters
        public class TradingViewAdvancedChartParameters
        {
            public TradingViewCryptoExchange exchange { get; set; } = TradingViewCryptoExchange.none;
            public string symbol { get; set; } = "LTC";
            public string market { get; set; } = "BTC";

            public TradingViewChartInterval interval { get; set; } = TradingViewChartInterval.Minute_15;
            public string timezone { get; set; } = "America/New_York";

            public int width { get; set; } = 980;
            public int height { get; set; } = 610;
            public Boolean autosize { get; set; } = true;

            public TradingViewColorTheme theme { get; set; } = TradingViewColorTheme.Light;
            public TradingViewChartStyle style { get; set; } = TradingViewChartStyle.Candles;

            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW

            // PROPERTIES
            public string toolbar_bg { get; set; } = "#f1f3f6";


            // Top Tool Bar
            public Boolean hide_top_toolbar { get; set; } = true;

            // Bottom Tool Bar
            public Boolean withdateranges { get; set; } = false;

            public Boolean allow_symbol_change { get; set; } = true;

            // Get Image Button
            public Boolean save_image { get; set; } = true;

            // ShowDrawingToolsBar
            public Boolean hide_side_toolbar { get; set; } = false;

            // hideideas
            public Boolean hideideas { get; set; } = false;

            // Show ideas button
            public Boolean hideideasbutton { get; set; } = false;

            public Boolean show_popup_button { get; set; } = false;
            public int popup_width { get; set; } = 1000;
            public int popup_height { get; set; } = 650;

            public Boolean enable_publishing { get; set; } = false;

            // Active Referral Program
            public Boolean no_referral_id { get; set; } = true;
            public string referral_id { get; set; } = string.Empty;

            // Watchlist
            public Boolean ShowWatchlist { get; set; } = false;
            public Boolean ShowIndicators { get; set; } = false;

            // EXTRAS
            public Boolean details { get; set; } = false;
            public Boolean stocktwits { get; set; } = false;
            public Boolean headlines { get; set; } = false;
            public Boolean hotlist { get; set; } = false;
            public Boolean calendar { get; set; } = false;
            
            public List<TradingViewWatchlistItem> WatchList { get; set; } = new List<TradingViewWatchlistItem>();
            //public List<TradingViewIndicator> IndicatorList { get; set; } = new List<TradingViewIndicator>();
            //public TradingViewIndicator studies { get; set; }
            //public List<TradingViewIndicator> studies { get; set; } = new List<TradingViewIndicator>() { TradingViewIndicator.MACD, TradingViewIndicator.BB, TradingViewIndicator.PSAR };
            public List<TradingViewIndicator> studies { get; set; } = new List<TradingViewIndicator>();
            
            public string GetSymbolString()
            {
                if (symbol != null)
                {
                    return exchange.ToString().ToUpper() + ":" + symbol.ToUpper() + market.ToUpper();
                }
                else
                {
                    return string.Empty;
                }
            }
            
        }
        public class TradingViewCryptocurrencyMarketParameters
        {
            public TradingViewCryptocurrencyMarketDisplayCurrency displayCurrency { get; set; } = TradingViewCryptocurrencyMarketDisplayCurrency.USD;
            public TradingViewCryptocurrencyMarketDefaultColumn defaultColumn { get; set; } = TradingViewCryptocurrencyMarketDefaultColumn.overview;
            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW

            public int width { get; set; } = 1000;
            public int height { get; set; } = 500;
            public Boolean autosize { get; set; } = true;
        }
        public class TradingViewEconomicCalendarParameters
        {
            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW
            public int width { get; set; } = 510;
            public int height { get; set; } = 610;
            public Boolean autosize { get; set; } = true;

            public string importanceFilter { get; set; } = "-1,0,1";
            public string currencyFilter { get; set; } = string.Empty;
        }
        public class TradingViewForexParameters
        {
            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW

            public int width { get; set; } = 770;
            public int height { get; set; } = 400;
            public Boolean autosize { get; set; } = true;

            public TradingViewCurrency[] currencies { get; set; }
        }
        public class TradingViewFundamentalChartParameters
        {
            public TradingViewCryptoExchange exchange { get; set; }

            public string symbol { get; set; }
            public string market { get; set; }

            public TradingViewChartInterval interval { get; set; } = TradingViewChartInterval.Minute_15;

            public int width { get; set; } = 980;
            public int height { get; set; } = 610;
            public Boolean autosize { get; set; } = true;

            public TradingViewColorTheme theme { get; set; } = TradingViewColorTheme.Light;
            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW

            public Boolean percentageScale { get; set; } = true;

            public string toolbarBackgroundColor { get; set; } = "#f1f3f6";
            public Boolean ShowTopToolbar { get; set; } = true;
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

            public string GetSymbolString()
            {
                return exchange.ToString().ToUpper() + ":" + symbol.ToUpper() + market.ToUpper();
            }
        }
        public class TradingViewMarketMoversParameters
        {
            public TradingViewExchange exchange { get; set; } = TradingViewExchange.US;
            public Boolean showChart { get; set; } = true;
            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW

            public int width { get; set; } = 400;
            public int height { get; set; } = 600;
            public Boolean autosize { get; set; } = true;

            public string plotLineColorGrowing { get; set; } = "rgba(60, 188, 152, 1)";
            public string plotLineColorFalling { get; set; } = "rgba(255, 74, 104, 1)";
            public string gridLineColor { get; set; } = "rgba(242, 242, 242, 1)";
            public string scaleFontColor { get; set; } = "rgba(218, 221, 224, 1)";
            public string belowLineFillColorGrowing { get; set; } = "rgba(60, 188, 152, 0.05)";
            public string belowLineFillColorFalling { get; set; } = "rgba(255, 74, 104, 0.05)";
            public string symbolActiveColor { get; set; } = "rgba(242, 250, 254, 1)";
        }
        public class TradingViewMarketOverviewParameters
        {
            public Boolean showChart { get; set; } = true;
            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW

            public int width { get; set; } = 400;
            public int height { get; set; } = 660;
            public Boolean autosize { get; set; } = true;

            public string plotLineColorGrowing { get; set; } = "rgba(60, 188, 152, 1)";
            public string plotLineColorFalling { get; set; } = "rgba(255, 74, 104, 1)";
            public string gridLineColor { get; set; } = "rgba(233, 233, 234, 1)";
            public string scaleFontColor { get; set; } = "rgba(218, 221, 224, 1)";
            public string belowLineFillColorGrowing { get; set; } = "rgba(60, 188, 152, 0.05)";
            public string belowLineFillColorFalling { get; set; } = "rgba(255, 74, 104, 0.05)";
            public string symbolActiveColor { get; set; } = "rgba(242, 250, 254, 1)";

            public List<TradingViewMarketOverviewTab> tabs { get; set; } = new List<TradingViewMarketOverviewTab>();
        }
        public class TradingViewMarketQuotesParameters
        {
            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW

            public int width { get; set; } = 770;
            public int height { get; set; } = 450;
            public Boolean autosize { get; set; } = true;

            public List<TradingViewMarketQuotesTab> tabs { get; set; } = new List<TradingViewMarketQuotesTab>();
        }
        public class TradingViewStockScreenerParameters
        {
            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW

            public int width { get; set; } = 1100;
            public int height { get; set; } = 500;
            public Boolean autosize { get; set; } = true;

            public Boolean showToolbar { get; set; } = true;

            public TradingViewExchangeMarket exchangeMarket { get; set; } = TradingViewExchangeMarket.exchange_america;
            public TradingViewStockScreenerDefaultColumn defaultColumn = TradingViewStockScreenerDefaultColumn.overview;
            public TradingViewStockScreenerDefaultScreen defaultScreen = TradingViewStockScreenerDefaultScreen.top_gainers;
        }
        public class TradingViewSymbolOverviewParameters
        {
            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW

            public int width { get; set; } = 1000;
            public int height { get; set; } = 400;
            public Boolean autosize { get; set; } = false;

            public Boolean chartOnly { get; set; } = false;

            public string greyText { get; set; } = "Quotes by";
            public string gridLineColor { get; set; } = "#e9e9ea";
            public string fontColor { get; set; } = "#83888D";
            public string underLineColor { get; set; } = "#dbeffb";
            public string trendLineColor { get; set; } = "#4bafe9";

            public List<TradingViewSymbolOverview> symbols { get; set; } = new List<TradingViewSymbolOverview>();
            /*
            public List<TradingViewSymbolOverview> symbols { get; set; } = new List<TradingViewSymbolOverview>()
            {
                new TradingViewSymbolOverview(){ symbol = "BTC", market = "USD", exchange = TradingViewCryptoExchange.Coinbase, interval = TradingViewSymbolOverviewInterval.day_1d, tabName = "BTC"},
                new TradingViewSymbolOverview(){ symbol = "LTC", market = "USD", exchange = TradingViewCryptoExchange.Coinbase, interval = TradingViewSymbolOverviewInterval.day_1d, tabName = "LTC" },
                new TradingViewSymbolOverview(){ symbol = "ETH", market = "USD", exchange = TradingViewCryptoExchange.Coinbase, interval = TradingViewSymbolOverviewInterval.day_1d, tabName = "ETH" }
            };
            */
        }
        public class TradingViewTickerParameters
        {
            public string locale { get; set; } = "en"; // ONLY ENGLISH FOR NOW
            public List<TradingViewTicker> symbols { get; set; } = new List<TradingViewTicker>();
        }
        #endregion
        #region DATAMODELS_Widgets
        public class TradingViewMarketOverviewTab
        {
            public List<TradingViewMarketOverviewTabItem> symbols { get; set; } = new List<TradingViewMarketOverviewTabItem>();
            public string title { get; set; }
        }
        public class TradingViewMarketOverviewTabItem
        {
            [Description("Symbol : ex. COINBASE:BTCUSD")]
            public string s { get; set; }
            [Description("Description")]
            public string d { get; set; }
        }      
        public class TradingViewMarketQuotesTab
        {
            public string name { get; set; }
            public List<TradingViewMarketQuotesTabItem> symbols { get; set; } = new List<TradingViewMarketQuotesTabItem>();
        }
        public class TradingViewMarketQuotesTabItem
        {
            public string name { get; set; }
            public string displayName { get; set; }
        }
        public class TradingViewSymbolOverview
        {
            public TradingViewCryptoExchange exchange { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
            public string tabName { get; set; }
            public TradingViewSymbolOverviewInterval interval { get; set; } = TradingViewSymbolOverviewInterval.day_1d;

            public string GetSymbolString()
            {
                return exchange.ToString().ToUpper() + ":" + symbol.ToUpper() + market.ToUpper() + "|" + EnumUtils.GetDescription(interval);
            }
        }
        public class TradingViewTicker
        {
            public string description { get; set; }
            public string proName { get; set; }
        }
        public class TradingViewWatchlistItem
        {
            public TradingViewCryptoExchange exchange { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }

            public string GetSymbolString()
            {
                return exchange.ToString().ToUpper() + ":" + symbol.ToUpper() + market.ToUpper();
            }
        }
        #endregion
        #endregion DataModels
    }
}