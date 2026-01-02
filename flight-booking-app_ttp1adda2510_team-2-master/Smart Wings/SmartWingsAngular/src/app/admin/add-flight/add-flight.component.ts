import { Component } from '@angular/core';
import { AddFlight, Aircraft } from './add-flight';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-flight',
  imports: [FormsModule, CommonModule],
  templateUrl: './add-flight.component.html',
  styleUrl: './add-flight.component.css',
})
export class AddFlightComponent {
  // Model for the new flight being added
  newFlight: AddFlight = {
    flightNumber: '',
    origin: '',
    destination: '',
    departureTime: new Date(),
    arrivalTime: new Date(),
    aircraftId: '',
    status: '',
    priceEconomy: 0,
    priceBusiness: 0,
  };
  // List of cities for flight search
  cities = [
    'Agartala',
    'Agatti',
    'Ahmedabad',
    'Aizawl',
    'Akola',
    'Allahabad',
    'Amritsar',
    'Aurangabad',
    'Ayodhya',
    'Bagdogra',
    'Bengaluru',
    'Bhopal',
    'Bhubaneswar',
    'Chandigarh',
    'Chennai',
    'Coimbatore',
    'Daman',
    'Darbhanga',
    'Dehradun',
    'Delhi',
    'Dibrugarh',
    'Dimapur',
    'Goa',
    'Guwahati',
    'Hyderabad',
    'Imphal',
    'Indore',
    'Itanagar',
    'Jaipur',
    'Jammu',
    'Jamnagar',
    'Jeypore',
    'Jodhpur',
    'Kannur',
    'Kanpur',
    'Kochi',
    'Kolkata',
    'Kozhikode',
    'Lucknow',
    'Madurai',
    'Mangaluru',
    'Mumbai',
    'Nagpur',
    'Nashik',
    'Pune',
    'Rajkot',
    'Ranchi',
    'Shillong',
    'Shimla',
    'Siliguri',
    'Srinagar',
    'Surat',
    'Thiruvananthapuram',
    'Tiruchirappalli',
    'Tirupati',
    'Udaipur',
    'Vadodara',
    'Varanasi',
    'Vijayawada',
    'Visakhapatnam',
  ];

  aircraftList: Aircraft[] = [];

  successMessage: string | null = null;
  errorMessage: string | null = null;

  isAdded: boolean = false;

  // API endpoints
  private postUrl = 'http://localhost:5152/api/flights';
  private getAircraftUrl = 'http://localhost:5152/api/flights/aircrafts';

  constructor(private http: HttpClient) {}
  // Initialize component
  ngOnInit() {
    this.http.get<Aircraft[]>(this.getAircraftUrl).subscribe(
      (response: Aircraft[]) => {
        this.aircraftList = response;
      },
      (error) => {
        console.error('Error fetching aircraft list:', error);
      }
    );
  }
  // Adds a new flight
  addFlight() {
    // Validate form fields
    if (
      !this.newFlight.aircraftId ||
      !this.newFlight.flightNumber ||
      !this.newFlight.origin ||
      !this.newFlight.destination ||
      !this.newFlight.departureTime ||
      !this.newFlight.arrivalTime ||
      !this.newFlight.status ||
      !this.newFlight.priceEconomy ||
      !this.newFlight.priceBusiness
    ) {
      this.errorMessage = 'Please fill in all required fields.';
      return;
    }

    this.successMessage = 'Adding Flight, Please wait';
    // Prepare flight data for submission
    const flightToSend = {
      ...this.newFlight,
      departureTime: new Date(this.newFlight.departureTime).toISOString(),
      arrivalTime: new Date(this.newFlight.arrivalTime).toISOString(),
    };

    console.log(flightToSend);
    // Send flight data to the server
    this.http.post(this.postUrl, flightToSend).subscribe(
      (response) => {
        this.successMessage = 'Flight added successfully!';
        this.errorMessage = null;
      },
      (error) => {
        console.error('Error adding flight:', error);
        this.errorMessage = 'Failed to add flight. Please try again.';
        this.isAdded = false;
      }
    );
    // Reset form
    this.newFlight = {
      flightNumber: '',
      origin: '',
      destination: '',
      departureTime: new Date(),
      arrivalTime: new Date(),
      aircraftId: '',
      status: '',
      priceEconomy: 0,
      priceBusiness: 0,
    };

    this.isAdded = true;
  }
}
