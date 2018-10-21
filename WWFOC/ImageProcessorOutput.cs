using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WWFOC
{
    public class ImageProcessorOutput : INotifyPropertyChanged
    {
        private bool? _userDecision = true;

        #region INotify

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
        
        #endregion

        public FileInfo SourceFile { get; set; }

        public string Title
        {
            get
            {
                string decisionPrefix = "";
                if (UserDecision == true)
                {
                    decisionPrefix = "✔ ";
                }
                else if (UserDecision == false)
                {
                    decisionPrefix = "✘ ";
                }
                else
                {
                    decisionPrefix = "  ";
                }
                return $"{decisionPrefix}{SourceFile.Name}";
            }
        }

        public IReadOnlyList<ImageOutput> Images { get; set; }

        public IReadOnlyList<Target> Targets { get; set; }

        public bool Positive => Targets.Any();

        public bool? UserDecision
        {
            get => _userDecision;
            set
            {
                _userDecision = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(Title));
            }
        }

        public bool SignificantlyDifferentFrom(ImageProcessorOutput b)
        {
            const int treshold = 10;
            foreach (Target target in Targets)
            {
                if (!b.Targets.Any(
                    t => GetDistance(t.Center.X, t.Center.Y, target.Center.X, target.Center.Y) < treshold))
                    return true;
            }

            return false;

        }

        public override string ToString()
        {
            return Title;
        }

        private static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}