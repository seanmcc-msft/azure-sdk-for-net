// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.BotService.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A Facebook page for Facebook channel registration
    /// </summary>
    public partial class FacebookPage
    {
        /// <summary>
        /// Initializes a new instance of the FacebookPage class.
        /// </summary>
        public FacebookPage()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FacebookPage class.
        /// </summary>
        /// <param name="id">Page id</param>
        /// <param name="accessToken">Facebook application access token. Value
        /// only returned through POST to the action Channel List API,
        /// otherwise empty.</param>
        public FacebookPage(string id, string accessToken)
        {
            Id = id;
            AccessToken = accessToken;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets page id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets facebook application access token. Value only returned
        /// through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Id == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
            if (AccessToken == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AccessToken");
            }
        }
    }
}
