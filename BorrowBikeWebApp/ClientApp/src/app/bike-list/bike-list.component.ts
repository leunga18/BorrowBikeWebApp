import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './bike-list.component.html'
})
export class BikeListComponent {
  public bikes: Bike[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Bike[]>(baseUrl + 'api/Bikes').subscribe(result => {
      this.bikes = result;
      for (let bike of this.bikes) {
        if (bike.status == "Error") {
          this.bikes = this.bikes.filter(item => item !== bike)
        }
      }
    }, error => console.error(error));
  }
}

