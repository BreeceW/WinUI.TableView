﻿using Microsoft.UI.Xaml;

namespace WinUI.TableView;

[StyleTypedProperty(Property = nameof(HeaderStyle), StyleTargetType = typeof(TableViewColumnHeader))]
public abstract class TableViewColumn : DependencyObject
{
    private TableViewColumnHeader? _headerControl;

    internal abstract FrameworkElement GenerateElement();
    internal abstract FrameworkElement GenerateEditingElement();

    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public double Width
    {
        get => (double)GetValue(WidthProperty);
        set => SetValue(WidthProperty, value);
    }

    public double MinWidth
    {
        get => (double)GetValue(MinWidthProperty);
        set => SetValue(MinWidthProperty, value);
    }

    public double MaxWidth
    {
        get => (double)GetValue(MaxWidthProperty);
        set => SetValue(MaxWidthProperty, value);
    }

    public bool CanResize
    {
        get => (bool)GetValue(CanResizeProperty);
        set => SetValue(CanResizeProperty, value);
    }

    public bool IsReadOnly
    {
        get => (bool)GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    public Style HeaderStyle
    {
        get => (Style)GetValue(HeaderStyleProperty);
        set => SetValue(HeaderStyleProperty, value);
    }

    public TableViewColumnHeader? HeaderControl
    {
        get => _headerControl;
        internal set
        {
            _headerControl = value;
            EnsureHeaderStyle();
        }
    }

    public bool IsAutoGenerated { get; internal set; }

    private void EnsureHeaderStyle()
    {
        if (_headerControl is not null && HeaderStyle is not null)
        {
            _headerControl.Style = HeaderStyle;
        }
    }

    public static readonly DependencyProperty HeaderStyleProperty = DependencyProperty.Register(nameof(HeaderStyle), typeof(Style), typeof(TableViewColumn), new PropertyMetadata(null, (d, _) => ((TableViewColumn)d).EnsureHeaderStyle()));
    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(object), typeof(TableViewColumn), new PropertyMetadata(null));
    public static readonly DependencyProperty WidthProperty = DependencyProperty.Register(nameof(Width), typeof(double), typeof(TableViewColumn), new PropertyMetadata(200d));
    public static readonly DependencyProperty MinWidthProperty = DependencyProperty.Register(nameof(MinWidth), typeof(double), typeof(TableViewColumn), new PropertyMetadata(50d));
    public static readonly DependencyProperty MaxWidthProperty = DependencyProperty.Register(nameof(MaxWidth), typeof(double), typeof(TableViewColumn), new PropertyMetadata(double.PositiveInfinity));
    public static readonly DependencyProperty CanResizeProperty = DependencyProperty.Register(nameof(CanResize), typeof(bool), typeof(TableViewColumn), new PropertyMetadata(true));
    public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(nameof(IsReadOnly), typeof(bool), typeof(TableViewColumn), new PropertyMetadata(false));
}
