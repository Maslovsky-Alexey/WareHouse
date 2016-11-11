function GenerateRedirectUri(token) {
    var redirect_uri = URI(window.location.href).search(true).redirect_uri;
    var uri = URI(redirect_uri);

    if (token)
        uri.addSearch("token", token);

    return uri.href();
}


exports.GenerateRedirectUri = GenerateRedirectUri;