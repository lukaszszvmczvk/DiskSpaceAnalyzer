using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace forms
{
    public static class Chart
    {
        public static Dictionary<string, long> dataCount = new Dictionary<string, long>();
        public static Dictionary<string, long> dataSize = new Dictionary<string, long>();
        public static Dictionary<string, long> groupedDataCount = new Dictionary<string, long>();
        public static Dictionary<string, long> groupedDataSize = new Dictionary<string, long>();
        static Color[] colors = new Color[10];

        public static void GroupData()
        {
            groupedDataCount.Clear();
            groupedDataSize.Clear();

            groupedDataCount = dataCount.OrderByDescending(x => x.Value)
                           .Take(9)
                           .ToDictionary(x => x.Key, x => x.Value);
            var otherDataCount = dataCount.Where(x => !groupedDataCount.ContainsKey(x.Key))
                                          .Sum(x => x.Value);
            if (otherDataCount > 0)
                groupedDataCount.Add("Other", otherDataCount);

            groupedDataSize = dataSize.OrderByDescending(x => x.Value)
                           .Take(9)
                           .ToDictionary(x => x.Key, x => x.Value);
            var otherDataSize = dataSize.Where(x => !groupedDataSize.ContainsKey(x.Key))
                                          .Sum(x => x.Value);
            if (otherDataSize > 0)
                groupedDataSize.Add("Other", otherDataSize);

        }
        public static void DrawBarCharts(Graphics g, int width, int height)
        {
            ChooseColors();
            if (dataCount.Count > 0)
            {
                GroupData();
                int barWidth = width / 3;
                DrawBarChart(g, groupedDataCount, barWidth, height, width / 10);
                DrawBarChart(g, groupedDataSize, barWidth, height, barWidth + width / 5);
                //g.Dispose();
            }
        }
        // https://stackoverflow.com/questions/1335426/is-there-a-built-in-c-net-system-api-for-hsv-to-rgb
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
        static void ChooseColors()
        {
            for (int i = 0; i < 10; ++i)
            {
                colors[i] = ColorFromHSV(30 * i * 1.0f, 1.0f, 1.0f);
            }
        }
        public static string ConvertToScientificNotation(long number)
        {
            // Przykładowe wartości graniczne, dla których notacja wykładnicza jest zbędna
            if (number == 0 || Math.Abs(number) < 1000)
            {
                return number.ToString();
            }

            // Obliczenie wykładnika i mantysy
            int exponent = (int)Math.Log10(number);
            double mantissa = number / Math.Pow(10, exponent);

            // Zwrócenie wyniku w notacji wykładniczej
            return mantissa.ToString("0.#") + "*10^" + exponent.ToString();
        }
        public static void DrawBarChart(Graphics g, Dictionary<string, long> data, int width, int height, int start)
        {

            // Ustalanie stałych
            int topMargin = height / 10;
            int bottomMargin = 30;
            int barWidth = (int)((float)width / (data.Count + 2));
            int maxBarHeight = height - topMargin - bottomMargin;

            // Ustalanie ilości słupków do narysowania
            long barCount = Math.Min(data.Count, 10);

            // Ustalanie największej wartości z groupedDataCount
            long maxCount = data.Max(x => x.Value);

            // Ustalanie szerokości słupka
            long barSpacing = (width - barCount * barWidth) / (barCount + 1);

            // Ustalanie odstępów
            long x = barSpacing;

            var font = new Font("Arial", 7);

            // Rysowanie tła
            SolidBrush brush1 = new SolidBrush(Color.LightGray);
            g.FillRectangle(brush1, start, topMargin - bottomMargin, width, height - topMargin);
            brush1.Dispose();
            // Rysowanie podziałki
            for (int y = bottomMargin; y <= height - topMargin; y += maxBarHeight / 7)
            {
                g.DrawLine(Pens.Black, start + barSpacing, height - bottomMargin - y,
                    start + width - barSpacing, height - bottomMargin - y);
                string s = ConvertToScientificNotation((y * maxCount / maxBarHeight));
                SizeF textSize = g.MeasureString(s, font);
                g.DrawString(s, font, Brushes.Black, new PointF(start - (int)textSize.Width,
                    height - bottomMargin - y - font.Height / 2));
            }

            // Rysowanie słupków
            int i = 0;
            foreach (KeyValuePair<string, long> pair in data)
            {
                // Ustalanie wysokości słupka
                int barHeight = (int)((double)pair.Value / maxCount * maxBarHeight);

                // Rysowanie słupka
                Brush brush = new SolidBrush(colors[i % colors.Length]);
                g.FillRectangle(brush, x + start, height - bottomMargin - barHeight, barWidth, barHeight);
                g.DrawRectangle(new Pen(Color.Black, 2), x + start, height - bottomMargin - barHeight, barWidth, barHeight);
                brush.Dispose();

                // Rysowanie opisu pod słupkiem
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                g.DrawString(pair.Key, font, Brushes.Black, new Rectangle((int)x + start, height - bottomMargin, barWidth, bottomMargin), format);

                // Przesunięcie się na następny słupek
                x += barSpacing + barWidth;
                i++;
            }

        }
        public static void DrawBarChartsLog(Graphics g, int width, int height)
        {
            ChooseColors();
            if (dataCount.Count > 0)
            {
                GroupData();
                int barWidth = width / 3;
                DrawBarChartLog(g, groupedDataCount, barWidth, height, width / 10);
                DrawBarChartLog(g, groupedDataSize, barWidth, height, barWidth + width / 5);
            }
        }

        public static void DrawBarChartLog(Graphics g, Dictionary<string, long> data, int width, int height, int start)
        {
            // Ustalanie stałych
            int topMargin = height / 10;
            int bottomMargin = 30;
            int barWidth = (int)((float)width / (data.Count + 2));
            int maxBarHeight = height - topMargin - bottomMargin;

            // Ustalanie ilości słupków do narysowania
            long barCount = Math.Min(data.Count, 10);

            // Ustalanie największej wartości z data
            long maxCount = data.Max(x => x.Value);

            // Ustalanie szerokości słupka
            long barSpacing = (width - barCount * barWidth) / (barCount + 1);

            // Ustalanie odstępów
            long x = barSpacing;

            var font = new Font("Arial", 7);

            // Rysowanie tła
            SolidBrush brush1 = new SolidBrush(Color.LightGray);
            g.FillRectangle(brush1, start, topMargin - bottomMargin, width, height - topMargin);
            brush1.Dispose();

            // Rysowanie podziałki
            for (int j = 0; j <= 7; j++)
            {
                double m = Math.Log10(maxCount);
                double value = maxCount * Math.Pow(10, -j);
                if (m == 0)
                    m = 1;

                long y = height - bottomMargin - (int)((Math.Log10(value) / m) * maxBarHeight);

                g.DrawLine(Pens.Black, start + barSpacing, y, start + width - barSpacing, y);

                string s = ConvertToScientificNotation((long)value);
                SizeF textSize = g.MeasureString(s, font);
                g.DrawString(s, font, Brushes.Black, new PointF(start - (int)textSize.Width, y - font.Height / 2));
            }

            // Rysowanie słupków
            int i = 0;
            foreach (KeyValuePair<string, long> pair in data)
            {
                // Ustalanie wysokości słupka
                int barHeight = (int)((Math.Log10(pair.Value) / Math.Log10(maxCount)) * maxBarHeight);

                // Rysowanie słupka
                Brush brush = new SolidBrush(colors[i % colors.Length]);
                g.FillRectangle(brush, x + start, height - bottomMargin - barHeight, barWidth, barHeight);
                g.DrawRectangle(new Pen(Color.Black, 2), x + start, height - bottomMargin - barHeight, barWidth, barHeight);

                // Rysowanie opisu pod słupkiem
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                g.DrawString(pair.Key, font, Brushes.Black, new Rectangle((int)x + start, height - bottomMargin, barWidth, bottomMargin), format);
                brush.Dispose();
                // Przesunięcie się na następny słupek
                x += barSpacing + barWidth;
                i++;
            }
        }

    }
}
