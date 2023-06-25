//
//  ContentView.swift
//  BMI Client App
//
//  Created by Hiroto Aoyama on 2023/06/25.
//

import SwiftUI

struct ContentView: View {
    @State private var heightText = ""
    @State private var weightText = ""
    @State private var resultText = ""
    
    private let apiURL = "http://webstrar99.fulton.asu.edu/page8/Service1.svc/calculateBMI"
    
    var body: some View {
        VStack {
            Text("BMI API")
                .font(.title)
            
            TextField("Enter weight", text: $weightText)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            
            TextField("Enter height", text: $heightText)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            
            Button(action: getHealth) {
                Text("Get Health")
            }
            .padding()
            
            Text(resultText)
                .padding()
                .multilineTextAlignment(.center)
        }
        .padding()
    }
    
    private func getHealth() {
        guard let weight = Double(weightText), let height = Double(heightText)
        else {
            resultText = "Invalid input, weight and height must be decimals"
            return
        }
        
        let endpoint = "\(apiURL)?weight=\(weight)&height=\(height)"
        guard let url = URL(string: endpoint)
        else {
            resultText = "Invalid input"
            return
        }
        
        print(url)
        
        URLSession.shared.dataTask(with: url) { data, response, error in
            if let error = error {
                resultText = "Error: \(error.localizedDescription)"
                return
            }
            
            guard let data = data
            else {
                resultText = "Failed to obtain data"
                return
            }
            
            do {
                let decoder = JSONDecoder()
                let healthData = try decoder.decode(Health.self, from: data)
                resultText = "BMI: \(healthData.bmi)\n\n\(healthData.risk)"
            } catch {
                print("Error decoding JSON: \(error)")
            }
        }
        .resume()
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
