﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace StaticResourceMonitor.Downloads
{
    public class DownloadStorage
    {
        private const int INITIAL_CAPACITY = Byte.MaxValue + 1;

        private List<DownloadInfo> _downloads = new List<DownloadInfo>(INITIAL_CAPACITY);

        private object _locker = new object();

        public void AddDownload(DownloadInfo download)
        {
            lock (_locker)
            {
                _downloads.Add(download);
            }
        }

        public IEnumerable<DownloadInfo> GetAllDownloads()
        {
            return _downloads.AsEnumerable();
        }
    }
}