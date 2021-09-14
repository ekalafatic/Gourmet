import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/models/Recipe';
import { RecipeBook } from 'src/app/models/RecipeBook';
import { RecipeBookService } from './recipe-book.service';

@Component({
  selector: 'app-recipe-book',
  templateUrl: './recipe-book.component.html',
  styleUrls: ['./recipe-book.component.css']
})

export class RecipeBookComponent implements OnInit {

  titleRecipeBook = "Recipe Books"
  recipeBooks: RecipeBook[];
  recipes: Recipe[];

  constructor(private dataRecipeBooks: RecipeBookService) { }

  // Inicio del componente
  ngOnInit(): void {
    this.dataRecipeBooks.getRecipeBooks().subscribe(data => this.recipeBooks = data)
  }

}
