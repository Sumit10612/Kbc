import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faArrowDown, faCaretSquareLeft, faCaretSquareRight, faDiceOne, faEdit, faForward, faGem, faHome, faIndianRupeeSign, faInfoCircle, faPlay, faQuestionCircle, faRupeeSign, faSignIn, faSignOut, faTrash } from '@fortawesome/free-solid-svg-icons';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './component/home/home.component';
import { MenuComponent } from './component/menu/menu.component';
import { CreateGameComponent } from './component/create-game/create-game.component';
import { DashboardComponent } from './component/dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';
import { RulesComponent } from './component/rules/rules.component';
import { HttpClientModule } from '@angular/common/http';
import { ShowComponent } from './component/show/show.component';
import { AuthModule } from './auth/auth.module';
import { MsalRedirectComponent } from '@azure/msal-angular';
import { CreateQuestionComponent } from './component/create-question/create-question.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    CreateGameComponent,
    DashboardComponent,
    RulesComponent,
    ShowComponent,
    CreateQuestionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    FormsModule,
    HttpClientModule,
    AuthModule
  ],
  providers: [],
  bootstrap: [AppComponent, MsalRedirectComponent]
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIcons(
      faHome,
      faSignIn,
      faSignOut,
      faDiceOne,
      faQuestionCircle,
      faCaretSquareLeft,
      faCaretSquareRight,
      faInfoCircle,
      faGem,
      faIndianRupeeSign,
      faEdit,
      faTrash,
      faArrowDown,
      faPlay,
      faForward,
    )
  }
}
