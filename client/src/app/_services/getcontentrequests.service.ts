import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { DOMAIN } from '../const/constVariables';

@Injectable({
  providedIn: 'root'
})
export class GetcontentrequestsService {

  constructor(private http: HttpClient) {}


  getAllCusines()
  {
    return this.http.get(DOMAIN + '/info/allCuisines')
  }

  getProductCategories()
  {
    return this.http.get(DOMAIN + '/info/allProductCategories')
  }

  getProductsByCategory(id)
  {
    return this.http.get(DOMAIN + `/info/AllCategoryProductsOfCuisine/${id}`)
  }

}
