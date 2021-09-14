import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecipeBookComponent } from './components/recipe-book/recipe-book.component';
import { RecipeComponent } from './components/recipe-book/recipe/recipe.component';

const routes: Routes = [
  { path: '', component: RecipeBookComponent},
  { path: 'recipes/:recipeBookId', component: RecipeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
