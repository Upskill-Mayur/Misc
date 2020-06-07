using System;
using System.Threading;

namespace EventHandlerAndDelegates
{
    public class Video
    {
        public string Title { get; set; }
    }

    public class VideoEventArgs : EventArgs
    {
        public object Data { get; set; }
    }

    public class VideoEncoder
    {
        //old way
        //public delegate void VideoEncoderEventHandler(object source, VideoEventArgs videoEventArgs);
        //public event VideoEncoderEventHandler VideoEncoderEventHandlerEvent;

        //new way : no need to define seperate delegate.
        public EventHandler<VideoEventArgs> VideoEncoderEventHandlerEvent;
        public void Encode(Video video)
        {
            System.Console.WriteLine($"Video encoding is started for video {video.Title} ...");
            Thread.Sleep(3000);
            System.Console.WriteLine($"Video encoding is finished for video {video.Title} ...");

            OnVideoEncodingFinished(new VideoEventArgs() { Data = video });
        }

        protected virtual void OnVideoEncodingFinished(VideoEventArgs videoEventArgs)
        {
            if (VideoEncoderEventHandlerEvent != null)
            {
                VideoEncoderEventHandlerEvent(this, videoEventArgs);
            }
        }
    }


    public class VideoServiceManager
    {
        public void PerformVideoEncoding()
        {
            Video video = new Video();
            video.Title = "Gang of Wasseypur";
            VideoEncoder videoEncoder = new VideoEncoder();

            MailService mailService = new MailService();
            MessageService messageService = new MessageService();
            videoEncoder.VideoEncoderEventHandlerEvent += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoderEventHandlerEvent += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);
        }

    }

    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs videoEventArgs)
        {
            Video video = videoEventArgs.Data as Video;
            Console.WriteLine($"Sending email to notify that video encoding is done for {video.Title}");
        }
    }

    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs videoEventArgs)
        {
            Video video = videoEventArgs.Data as Video;
            Console.WriteLine($"Sending message to notify that video encoding is done for {video.Title}");
        }
    }
}