using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;

using ResizableFrameControl.Services;
using ResizableFrameControl.ViewModels;
using System.Windows.Controls.Primitives;

namespace ResizableFrameControl
{
    public class ViewModel : BaseViewModel
    {
        private Model? __Model = null;

        private IFileService FileService;
        private IDialogService DialogService;

        public IDelegateCommand MoveThumbDragDeltaCommand { protected set; get; }
       

        public ViewModel(IFileService fileService, IDialogService dialogService, Model model)
        {
            this.FileService = fileService;
            this.DialogService = dialogService;
            this.MoveThumbDragDeltaCommand = new DelegateCommand(MoveThumbDragDelta);

            __Model = model;
        }
        private void MoveThumbDragDelta(object? param)
        {
            DragDeltaEventArgs? dragDeltaEventArgs = param as DragDeltaEventArgs;
            if (dragDeltaEventArgs != null)
            {
                CanvasLeft += dragDeltaEventArgs.HorizontalChange;
                CanvasTop += dragDeltaEventArgs.VerticalChange;
            }
        }
        private void ResizeThumb_DragDelta(object? param)
        {
            DragDeltaEventArgs? e = param as DragDeltaEventArgs;

            if (e != null)
            {
                double deltaVertical, deltaHorizontal;
                /*
                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Bottom:
                        deltaVertical = Math.Min(-e.VerticalChange, item.ActualHeight - item.MinHeight);
                        CanvasHeight -= deltaVertical;
                        break;
                    case VerticalAlignment.Top:
                        deltaVertical = Math.Min(e.VerticalChange, item.ActualHeight - item.MinHeight);
                        CanvasTop += deltaVertical;
                        CanvasHeight -= deltaVertical;
                        break;
                    default:
                        break;
                }

                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        deltaHorizontal = Math.Min(e.HorizontalChange, item.ActualWidth - item.MinWidth);
                        CanvasLeft += deltaHorizontal;
                        CanvasWidth -= deltaHorizontal;
                        break;
                    case HorizontalAlignment.Right:
                        deltaHorizontal = Math.Min(-e.HorizontalChange, item.ActualWidth - item.MinWidth);
                        CanvasWidth -= deltaHorizontal;
                        break;
                    default: break;
                }
                */
                e.Handled = true;
            }
        }


        private double _canvasWidth = 100;
        public double CanvasWidth
        {
            get { return _canvasWidth; }
            set { _canvasWidth = value; OnPropertyChanged(nameof(CanvasWidth)); }
        }
        private double _cavasHeight = 100;
        public double CanvasHeight
        {
            get { return _cavasHeight; }
            set { _cavasHeight = value; OnPropertyChanged(nameof(CanvasHeight)); }
        }
        private double _canvasTop = 100;
        public double CanvasTop
        {
            get { return _canvasTop; }
            set { _canvasTop = value; OnPropertyChanged(nameof(CanvasTop)); }
        }
        private double _cavasLeft = 100;
        public double CanvasLeft
        {
            get { return _cavasLeft; }
            set { _cavasLeft = value; OnPropertyChanged(nameof(CanvasLeft)); }
        }

        private void Message(string caption, string message)
        {
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBox.Show(message, caption, buttons);
        }

    }
}