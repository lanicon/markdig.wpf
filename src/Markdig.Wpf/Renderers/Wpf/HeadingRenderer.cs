﻿// Copyright (c) 2016 Nicolas Musset. All rights reserved.
// This file is licensed under the MIT license. 
// See the LICENSE.md file in the project root for more information.

using System;
using System.Windows;
using System.Windows.Documents;
using Markdig.Syntax;
using Markdig.Wpf;

namespace Markdig.Renderers.Wpf
{
    public class HeadingRenderer : WpfObjectRenderer<HeadingBlock>
    {
        protected override void Write(WpfRenderer renderer, HeadingBlock obj)
        {
            var paragraph = new Paragraph();
            ComponentResourceKey styleKey = null;

            switch (obj.Level)
            {
                case 1: styleKey = Styles.Heading1StyleKey; break;
                case 2: styleKey = Styles.Heading2StyleKey; break;
                case 3: styleKey = Styles.Heading3StyleKey; break;
                case 4: styleKey = Styles.Heading4StyleKey; break;
                case 5: styleKey = Styles.Heading5StyleKey; break;
                case 6: styleKey = Styles.Heading6StyleKey; break;
            }

            if (styleKey != null)
            {
                paragraph.SetResourceReference(Paragraph.StyleProperty, styleKey);
            }

            renderer.BeginBlock(paragraph);
            renderer.WriteLeafInline(obj);

            paragraph.Inlines.AddRange(renderer.Inlines);
            renderer.EndBlock();
        }
    }
}
