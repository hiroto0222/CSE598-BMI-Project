//
//  HealthController.swift
//  BMI Client App
//
//  Created by Hiroto Aoyama on 2023/06/26.
//

import Foundation

class HealthController {
    private let apiURL = "http://webstrar99.fulton.asu.edu/page8/Service1.svc/calculateBMI"
    
    func getHealth(weight: Double, height: Double, completion: @escaping (Health?, Error?) -> Void) {
        let endpoint = "\(apiURL)?weight=\(weight)&height=\(height)"
        guard let url = URL(string: endpoint)
        else {
            completion(nil, NSError(domain: "Invalid input", code: 0, userInfo: nil))
            return
        }
        
        URLSession.shared.dataTask(with: url) { data, response, error in
            if let error = error {
                completion(nil, error)
                return
            }
            
            guard let data = data else {
                completion(nil, NSError(domain: "Failed to obtain data", code: 0, userInfo: nil))
                return
            }
            
            do {
                let decoder = JSONDecoder()
                let healthData = try decoder.decode(Health.self, from: data)
                completion(healthData, nil)
            } catch {
                completion(nil, error)
            }
        }
        .resume()
    }
}
