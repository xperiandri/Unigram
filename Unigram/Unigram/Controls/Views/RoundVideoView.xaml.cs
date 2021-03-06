﻿using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Unigram.Common;
using Unigram.Native;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.Media.Capture;
using Windows.Media.Effects;
using Windows.Media.MediaProperties;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Unigram.Controls.Views
{
    public sealed partial class RoundVideoView : ContentDialogBase
    {
        public RoundVideoView()
        {
            this.InitializeComponent();


            var visual = ElementCompositionPreview.GetElementVisual(this);
            visual.Clip = visual.Compositor.CreateInsetClip(0, 0, 0, 48);

            var capture = ElementCompositionPreview.GetElementVisual(Capture);
            _compositor = capture.Compositor;
            _capture = _compositor.CreateSpriteVisual();
            _capture.Size = new Vector2(200, 200);

            ImageLoader.Initialize(_compositor);
            ElementCompositionPreview.SetElementChildVisual(Capture, _capture);

            //Loaded += OnLoaded;
            //Unloaded += RoundVideoView_Unloaded;
        }

        private MediaPlayer _player;
        private MediaPlayerSurface _surface;
        private MediaCapturePreviewSource _preview;
        private Compositor _compositor;
        private SpriteVisual _capture;

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            OuterClip.Rect = new Rect(0, 0, e.NewSize.Width, e.NewSize.Height);
            InnerClip.Center = new Point(e.NewSize.Width / 2, e.NewSize.Height / 2);
        }

        public IAsyncAction SetAsync(MediaCapture media)
        {
            return Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                //var profile = MediaEncodingProfile.CreateMp4(VideoEncodingQuality.Vga);
                //profile.Audio = null;
                //profile.Container = null;

                //_preview = MediaCapturePreviewSource.CreateFromVideoEncodingProperties(profile.Video);
                //await media.StartPreviewToCustomSinkAsync(profile, _preview.MediaSink);

                //_player = new MediaPlayer();
                //_player.RealTimePlayback = true;
                //_player.AutoPlay = true;
                //_player.Source = _preview.MediaSource as IMediaPlaybackSource;

                //_surface = _player.GetSurface(_compositor);

                //var brush = _compositor.CreateSurfaceBrush(_surface.CompositionSurface);
                //brush.Stretch = CompositionStretch.UniformToFill;

                //var mask = ImageLoader.Instance.LoadCircle(200, Colors.White).Brush;
                //var graphicsEffect = new AlphaMaskEffect
                //{
                //    Source = new CompositionEffectSourceParameter("image"),
                //    AlphaMask = new CompositionEffectSourceParameter("mask")
                //};

                //var effectFactory = _compositor.CreateEffectFactory(graphicsEffect);
                //var effectBrush = effectFactory.CreateBrush();
                //effectBrush.SetSourceParameter("image", brush);
                //effectBrush.SetSourceParameter("mask", mask);

                //_capture.Brush = effectBrush;




                Capture.Source = media;
                await media.StartPreviewAsync();
            });
        }
    }
}
