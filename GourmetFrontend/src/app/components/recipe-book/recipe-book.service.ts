import { Injectable } from '@angular/core';
import { RecipeBook } from 'src/app/models/RecipeBook';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

// Con observable
export class RecipeBookService {
  private urlAPI = 'https://localhost:5001/api/recipebooks';
  
  constructor(private http: HttpClient) { }

  getRecipeBooks():Observable<RecipeBook[]>{
    return this.http.get<RecipeBook[]>(this.urlAPI);
  }
}
