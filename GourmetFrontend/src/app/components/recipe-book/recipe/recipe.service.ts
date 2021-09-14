import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Recipe } from 'src/app/models/Recipe';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  private urlAPI = 'https://localhost:5001/api/recipebooks';
  
  constructor(private http: HttpClient) { }

  getRecipe(recipeBookId: any):Observable<Recipe[]>{
    return this.http.get<Recipe[]>(this.urlAPI + '/' + recipeBookId + '/recipes');
  }
  
}
