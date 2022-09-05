export const environment = {
  production: false,
  azureAd: {
    clientId: (window as { [key: string]: any })['env']['azureAd_ClientId'] as string || '',
    authority: (window as { [key: string]: any })['env']['azureAd_Authority'] as string || '',
    redirectUri: (window as { [key: string]: any })['env']['azureAd_RedirectUri'] as string || ''
  },
  apiUrl: (window as { [key: string]: any })['env']['apiUrl'] as string || ''
};
