import { Component, Inject, OnInit } from '@angular/core';
// import { MsalBroadcastService, MsalGuardConfiguration, MsalService, MSAL_GUARD_CONFIG } from '@azure/msal-angular';
// import { InteractionStatus, RedirectRequest } from '@azure/msal-browser';
import { filter, Subject, takeUntil } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  loginDisplay = true;
  // private readonly _destroying$ = new Subject<void>();

  // constructor(private _authService: MsalService,
  //   private _broadcastService: MsalBroadcastService,
  //   @Inject(MSAL_GUARD_CONFIG) private _msalGuardConfig: MsalGuardConfiguration) { }

  ngOnInit(): void {
    // this._broadcastService.inProgress$
    //   .pipe(
    //     filter((status: InteractionStatus) => status === InteractionStatus.None),
    //     takeUntil(this._destroying$)
    //   )
    //   .subscribe(() => {
    //     this.setLoginDisplay();
    //   })
  }

  // setLoginDisplay(): void {
  //   this.loginDisplay = this._authService.instance
  //     .getAllAccounts().length > 0;
  // }

  // login(): void {
  //   if (this._msalGuardConfig.authRequest)
  //     this._authService.loginRedirect({ ...this._msalGuardConfig.authRequest } as RedirectRequest);
  //   else
  //     this._authService.loginRedirect();
  // }

  // logout(): void {
  //   this._authService.logoutRedirect({
  //     postLogoutRedirectUri: environment.azureAd.redirectUri
  //   });
  // }

  // ngOnDestroy(): void {
  //   this._destroying$.next(undefined);
  //   this._destroying$.complete();
  // }
}
