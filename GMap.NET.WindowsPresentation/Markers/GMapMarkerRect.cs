﻿using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace System.Windows.Controls
{
   public class GMapMarkerRect : GMapMarker
   {
      RectShape el = new RectShape();

      public GMapMarkerRect(GMap Map)
      {
         this.Map = Map;

         el.Width = 25;
         el.Height = 25;
         el.Stroke = Brushes.Blue;
         el.Fill = Brushes.Yellow;
         el.StrokeThickness = 2;
         el.MouseEnter += new MouseEventHandler(el_MouseEnter);
         el.MouseLeave += new MouseEventHandler(el_MouseLeave);
         el.MouseUp += new MouseButtonEventHandler(el_MouseUp);

         TextBlock.Foreground = Brushes.Blue;
      }

      void el_MouseUp(object sender, MouseButtonEventArgs e)
      {
         if(e.ChangedButton == MouseButton.Middle)
         {
            el.Width = 25;
            el.Height = 25;

            base.UpdateLocalPosition(Map);
         }
      }

      void el_MouseLeave(object sender, MouseEventArgs e)
      {
         Shape.Stroke = Brushes.Blue;
      }

      void el_MouseEnter(object sender, MouseEventArgs e)
      {
         Shape.Stroke = Brushes.Black;           
      }

      public override Shape Shape
      {
         get
         {
            return el;
         }
      }

      public override void SetShapeCenter()
      {
         Objects[Shape] = new Point(el.Width/2, el.Height/2);

         TextBlock.Measure(new Size(Double.MaxValue, Double.MaxValue));
         double visualHeight = TextBlock.DesiredSize.Height;
         double visualWidth = TextBlock.DesiredSize.Width;
         Objects[TextBlock] = new Point(-visualWidth/2, -visualHeight/2);
      }
   }
}
