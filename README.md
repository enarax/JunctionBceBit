World Without Fear Of Cancer
====
An award-winning project for the JUNCTIONx Budapest hackathon.

The team
---
* [Sándor Benke](https://github.com/benkes)
* [Marcell Tóth](https://github.com/marcelltoth)

The challenge
---
The challenge was provided and mentored by medtech company Varian Medical Systems. 
>Mr. Stern arrives to the hospital with negging pain in his head and eyes. In the radiology department he gets a MR (Magnetic Resonance) examination. While the radiologist and the reading physician checks the frontal lobe of the brain and the optic nerves they do not find any suspicious deformation, so Mr. Stern calms down and after 1 week with some pills the pain vanishes.

>Mr. Stern 6 months later visits the hospital with heavier symptoms. The recent examinations unveil a mature cancer in the cerebral cortex.

>Couldn’t the cancer have been detected 6 months earlier on the MR scan?

>A MR machine in a hospital’s radiology department scans 20 patients per day. One study - depending on the scanned body region – can be 300 slices (piece of image). In one year, one hospital’s one designated MR machine creates more than 2 million images and already one image is enough to detect cancer. However, most of the patients are examined due to different reasons but the information of an early stage cancer could be there, hidden on one of the MR images.

>Your team should plan a system, which can find typical signs of brain cancer in a large dataset. The solution needs to be adjustable to a large scale.

Our solution
---
Due to the small number of data samples they provided to us we decided to not use machine learning and focus on more traditional computer vision instead.

First we had to open and parse the *DICOM* files, which are the complex container format for medical imaging data. 

We extracted the raw bitmaps, then ran some preprocessing on them: Dynamic range normalization, grayscale conversion, then applying some filters (median, dilate) to prepare for the edge detection. 

When that was done the result was fed into OpenCV's Canny implementation, then contour finder. The resulting contour map was then analyzed via multiple heuristics to filter out possible tumorous areas.

We did not aim for absolute perfection, we focused on finding all tumors primarily, and then minimizing the amount of false positives as much as we could.

The technology used is based on the .NET stack, interfacing with OpenCV via [EmguCV](https://github.com/emgucv/emgucv). All processing is done massively parallelly via `Task`s to use all available CPU cores while not blocking the UI.

When the algorithm started to produce interesting results, Sándor wrote a simple user-friendly Windows Forms UI around the processor to provide a "doctor-usable" interface, that lets them go through the analyzed images really quickly. 

Results
---
With this project we ended up winning Varian's prize by finding 3 of the 4 tumours on the evaluation datasets they tested our solution on.

The other teams either did not find at least 3 or had much more false positives than our solution. No team found all four of them.

We are greatful for Varian for sponsoring this hackathon, by my personal opinion this was by far the most interesting challenge at the hackathon, and we had a great time both working with their team, and also meeting them at their Budapest headquarters (part of our prize).

