import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EventoDetalheComponent } from './components/eventos/evento-detalhe/evento-detalhe.component';
import { EventoListaComponent } from './components/eventos/evento-lista/evento-lista.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { UserComponent } from './components/user/user.component';


const routes: Routes = [
  {path:'', redirectTo:'dashboard',pathMatch:'full'},
  {path:'eventos', redirectTo:'eventos/lista'},
  {
    path:'eventos',
    component:EventosComponent,
    children: [
      {path:'detalhe', component:EventoDetalheComponent},
      {path:'detalhe/:id', component:EventoDetalheComponent},
      {path:'lista', component:EventoListaComponent}
    ],
  },
  {
    path : 'user',
    component:UserComponent,
    children:[
      {path:'login', component: LoginComponent},
      {path: 'registration', component:RegistrationComponent}
    ],
  },
  {path:'user/perfil', component:PerfilComponent},
  {path:'dashboard', component:DashboardComponent},
  {path:'contatos', component:ContatosComponent},
  {path:'palestrantes', component:PalestrantesComponent},
  {path:'**', redirectTo:'dashboard',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
