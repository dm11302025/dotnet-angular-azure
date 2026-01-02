import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
interface Flight {
  flightId: string;
  flightNumber: string;
  origin: string;
  destination: string;
  departureTime: string;
  aircraftModel: string;
  availableSeats: number;
}

@Component({
  selector: 'app-upcomingflights',
  imports: [FormsModule, CommonModule],
  templateUrl: './upcomingflights.component.html',
  styleUrls: ['./upcomingflights.component.css'],
})
export class UpcomingflightsComponent implements OnInit {
  flights: Flight[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadUpcomingFlights();
  }

  loadUpcomingFlights(): void {
    const url = 'http://localhost:5152/api/Dashboard/upcoming-flights';
    this.http.get<Flight[]>(url).subscribe({
      next: (data) => {
        this.flights = data;
      },
      error: (err) => {
        console.error('Failed to load upcoming flights:', err);
        this.flights = [];
      },
    });
  }
}
