using System;
using System.Windows.Input;
namespace KommandosEigene
{
    public static class meineKommandos
    {
        private static RoutedCommand ausgabe_eins;
        public static RoutedCommand Ausgabe_Eins
        {
            get { return ausgabe_eins; }
        }
        private static RoutedCommand ausgabe_zwei;
        public static RoutedCommand Ausgabe_Zwei
        {
            get { return ausgabe_zwei; }
        }

        static meineKommandos()
        {
            ausgabe_eins = new RoutedCommand();

            InputGestureCollection meineGestensammlung = new InputGestureCollection();

            KeyGesture meineGeste_StrgZ = new KeyGesture(Key.Z, ModifierKeys.Control);
            meineGestensammlung.Add(meineGeste_StrgZ);

            MouseGesture meineGeste_RightDoubleClick = new MouseGesture(MouseAction.RightDoubleClick);
            meineGestensammlung.Add(meineGeste_RightDoubleClick);

            ausgabe_zwei = new RoutedCommand("Kommando Zwei", typeof(meineKommandos), meineGestensammlung);
        }
    }
}
