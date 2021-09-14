import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Recipe } from 'src/app/models/Recipe';
import { RecipeService } from './recipe.service';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.css']
})
export class RecipeComponent implements OnInit {

  recipes: Recipe[];
  public opened = false;
  public openedButtonText = 'show';
  public recipeIdOpened: number;


  
  constructor(private dataRecipe: RecipeService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((paramMap: any) => {
      const {params} = paramMap;
      this.dataRecipe.getRecipe(params.recipeBookId).subscribe(data => this.recipes = data)
    })
  }
  
  public selected(recipeId: number){
    this.opened = !this.opened;
    this.recipeIdOpened = recipeId;

    if(this.opened){
      this.openedButtonText = 'close';
      
    }else{
      this.openedButtonText = 'show';
      this.recipeIdOpened = 10000000;
    }
  }

  public buttonName(recipeId: number): string{
    if(this.recipeIdOpened == recipeId){
      return 'close';
    }else{
      return 'show';
    }
  }

  
  panelOpenState = false;

}
