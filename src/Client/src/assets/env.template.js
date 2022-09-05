(function (window)
{
    window.env = window.env || {};

    // Environment variables
    window["env"]["apiUrl"] = "${API_URL}";
    window["env"]["azureAd_ClientId"] = "${AZUREAD_CLIENTID}";
    window["env"]["azureAd_Authority"] = "${AZUREAD_AUTHORITY}";
    window["env"]["azureAd_RedirectUri"] = "${AZUREAD_REDIRECTURI}";
})(this);