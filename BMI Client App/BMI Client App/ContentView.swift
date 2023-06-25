//
//  ContentView.swift
//  BMI Client App
//
//  Created by Hiroto Aoyama on 2023/06/25.
//

import SwiftUI

struct ContentView: View {
    @State private var height = 0.0
    @State private var weight = 0.0
    
    var body: some View {
        VStack {
            Text("BMI API")
                .font(.title)
        }
        .padding()
    }
    
    func getHealth() async throws -> Health {
        let endpoint = "http://webstrar99.fulton.asu.edu/page8/Service1.svc/calculateBMI?"
        
        guard let url = URL(string: endpoint)
        else {
            throw GHError.invalidURL
        }
        
        let (data, res) = try await URLSession.shared.data(from: url)
        
        guard let res = res as? HTTPURLResponse, res.statusCode == 200
        else {
            throw GHError.invalidResponse
        }
        
        do {
            let decoder = JSONDecoder()
            decoder.keyDecodingStrategy = .convertFromSnakeCase
            return try decoder.decode(Health.self, from: data)
        } catch {
            throw GHError.invalidData
        }
    }
}

struct Health: Codable {
    let bmi: Double
    let risk: String
    let more: [String]
}

enum GHError: Error {
    case invalidURL
    case invalidResponse
    case invalidData
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
