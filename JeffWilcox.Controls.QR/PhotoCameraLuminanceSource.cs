//
// Copyright (c) 2012 Jeff Wilcox
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

// See also: http://silverlightzxing.codeplex.com/

using System;
using ZXing;

namespace JeffWilcox.Controls
{
    public class PhotoCameraLuminanceSource : LuminanceSource
    {
        public byte[] PreviewBufferY { get; private set; }

        public PhotoCameraLuminanceSource(int width, int height)
            : base(width, height)
        {
            PreviewBufferY = new byte[width * height];
        }

        public override byte[] Matrix
        {
            get { return PreviewBufferY; }
        }

        public override byte[] getRow(int y, byte[] row)
        {
            if (row == null || row.Length < Width)
            {
                row = new byte[Width];
            }

            for (int i = 0; i < Height; i++)
                row[i] = PreviewBufferY[i * Width + y];

            return row;
        }
    }
}
