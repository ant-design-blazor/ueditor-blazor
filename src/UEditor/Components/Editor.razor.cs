﻿using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace UEditor
{
    public partial class Editor : ComponentBase, IDisposable
    {
        /// <summary>
        /// Markdown Content
        /// </summary>
        [Parameter]
        public string Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    _waitingUpdate = true;
                }
            }
        }

        [Parameter] public EventCallback<string> ValueChanged { get; set; }

        /// <summary>
        /// Html Content
        /// </summary>
        [Parameter]
        public string Html { get; set; }

        [Parameter] public EventCallback<string> HtmlChanged { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Options { get; set; }

        [Parameter]
        public string Mode { get; set; }

        [Parameter]
        public string Placeholder { get; set; }

        [Parameter]
        public string Height {
            get => _heightValue; 
            set {
                SetHeight(value);
                _heightValue = value;
            }
        }

        [Parameter]
        public string Width { get; set; }

        [Parameter]
        public string MinHeight { get; set; }

        [Parameter]
        public bool Outline { get; set; }

        private ElementReference _ref;

        private bool _editorRendered = false;
        private bool _waitingUpdate = false;
        private string _value, _heightValue = "500";

        private bool _afterFirstRender = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                _afterFirstRender = true;
                await CreateUEditor();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Options ??= new Dictionary<string, object>();

            Options["Mode"] = Mode ?? "ir";
            Options["Placeholder"] = Placeholder ?? "";
            Options["Height"] = int.TryParse(Height, out var h) ? h : (object)Height;
            Options["Width"] = int.TryParse(Width, out var w) ? w : (object)Width;
            Options["MinHeight"] = int.TryParse(MinHeight, out var m) ? m : (object)MinHeight;
            Options["Options"] = Outline;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            if (_waitingUpdate && _editorRendered)
            {
                _waitingUpdate = false;
                await SetValue(_value);
            }
        }

        public async ValueTask<string> GetValueAsync()
        {
            if (_editorRendered)
            {
                return await GetValue();
            }

            return string.Empty;
        }

        public void Dispose()
        {
            Destroy();
        }
    }
}
