# Analyze Image API

## Overview: 
This RESTful API which is in its version 1.0 demonstrates analysis of an image content with a sample image. 
Analysis result include: Detection of objects, Facial Recognition, Emotion, Location of Event, Landmarks.etc 
An image and email address is sent to the api endpoint to which the analysis result is sent to the provided email as an attachment.
The image analyzed is stored in a database and the date of analysis created automatically upon analysis.

## Aim:
This api can be used for crime monitoring and detection for an area. 
To achieve this, a step further in the innovation can be employed being the application of IoT. 
In this case, CCTV cameras are mounted on specific locations so as to capture images on realtime. The images are downloaded from a workstation which is passed to a platform-specific application(desktop or web or mobile app) for processing.
Information processed from the image can be used to track criminals with a trusted accuracy as provided from the api result.

## Project Dependencies:
The Computer Vision AI service from Microsoft was used for this project. To use this service, please signup on Azure and follow the processes to obtain an endpoint and key which will be needed.
SendGrid API was used for sending of emails. To use this, do signup on the portal to obtain an api key.

## Development Tools:
* Visual Studio 2019
* ASP.NET Core 3.0
* Microsoft SQL Server

**Link to Analyze Image API V1.0 documentation:**
https://documenter.getpostman.com/view/8070931/SW7UaqK7?version=latest


Contributions are highly welcomed and needed.


