﻿using System;
using System.Collections.Generic;

namespace CronetSharp
{
    public class UrlRequestParams
    {
        public IntPtr Pointer { get; }

        public UrlRequestParams()
        {
            Pointer = Cronet.UrlRequestParams.Cronet_UrlRequestParams_Create();
        }
        
        public UrlRequestParams(IntPtr urlRequestParamsPtr)
        {
            Pointer = urlRequestParamsPtr;
        }

        public void Destroy()
        {
            Cronet.UrlRequestParams.Cronet_UrlRequestParams_Destroy(Pointer);
        }

        public void AddHeader(string header, string value)
        {
            var httpHeader = new HttpHeader(header, value);
            Cronet.UrlRequestParams.Cronet_UrlRequestParams_request_headers_add(Pointer, httpHeader.Pointer);
        }

        /// <summary>
        /// Set the request headers.
        /// </summary>
        /// <param name="headers"></param>
        public void SetHeaders(IList<HttpHeader> headers)
        {
            foreach (var header in headers)
                Cronet.UrlRequestParams.Cronet_UrlRequestParams_request_headers_add(Pointer, header.Pointer);
        }
        
        /// <summary>
        /// Set or get the headers.
        /// </summary>
        public IList<HttpHeader> Headers
        {
            set => SetHeaders(value);
        }

        /// <summary>
        /// Marks that the executors this request will use to notify callbacks (for UploadDataProviders and UrlRequest.Callbacks) is intentionally performing inline execution.
        /// </summary>
        public bool AllowDirectExecutor
        {
            get => Cronet.UrlRequestParams.Cronet_UrlRequestParams_allow_direct_executor_get(Pointer);
            set => Cronet.UrlRequestParams.Cronet_UrlRequestParams_allow_direct_executor_set(Pointer, value);
        }

        /// <summary>
        /// Disables cache for the request.
        /// </summary>
        public bool DisableCache
        {
            get => Cronet.UrlRequestParams.Cronet_UrlRequestParams_disable_cache_get(Pointer);
            set => Cronet.UrlRequestParams.Cronet_UrlRequestParams_disable_cache_set(Pointer, value);
        }

        /// <summary>
        /// Sets the HTTP method verb to use for this request.
        /// The default when this method is not called is "GET" if the request has no body or "POST" if it does.
        /// Supported methods: "GET", "HEAD", "DELETE", "POST" or "PUT".
        /// </summary>
        public string HttpMethod
        {
            get => Cronet.UrlRequestParams.Cronet_UrlRequestParams_http_method_get(Pointer);
            set => Cronet.UrlRequestParams.Cronet_UrlRequestParams_http_method_set(Pointer, value);
        }

        /// <summary>
        /// Sets priority of the request.
        /// </summary>
        public Cronet.RequestPriority Priority
        {
            get => Cronet.UrlRequestParams.Cronet_UrlRequestParams_priority_get(Pointer);
            set => Cronet.UrlRequestParams.Cronet_UrlRequestParams_priority_set(Pointer, value);
        }
    }
}