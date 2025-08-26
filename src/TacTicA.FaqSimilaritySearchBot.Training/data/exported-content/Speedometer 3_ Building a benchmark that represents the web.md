URL:https://blog.chromium.org/2024/03/speedometer-3-building-benchmark-that.html
# Speedometer 3: Building a benchmark that represents the web
- **Published**: 2024-03-11T09:00:00.000-07:00
[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiwhyphenhypheng0_39U6yzt-pOO8aVmKnuz6fn2Nk2Vx5Rs-ypGPUDRiOG4v8ItqlD_WLSRfku6utJy6luWI5iDOtwEor5v69en_XiWU-akxtTmCgR8Mm-6NfjW6weeEoXT6msXLmbxGzJ8ZvzKKOEjOv0SZH-RhXHKdHG7I_6TmE5hJq5VFSrXyUV5d8K7zE0KLYJg/s16000/The%20Fast%20+%20The%20Curious%20Logo_Revised_Header.jpg)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiwhyphenhypheng0_39U6yzt-pOO8aVmKnuz6fn2Nk2Vx5Rs-ypGPUDRiOG4v8ItqlD_WLSRfku6utJy6luWI5iDOtwEor5v69en_XiWU-akxtTmCgR8Mm-6NfjW6weeEoXT6msXLmbxGzJ8ZvzKKOEjOv0SZH-RhXHKdHG7I_6TmE5hJq5VFSrXyUV5d8K7zE0KLYJg/s564/The%20Fast%20+%20The%20Curious%20Logo_Revised_Header.jpg)

  

*Today’s The Fast and the Curious post covers the [release](https://browserbench.org/announcements/speedometer3/) of Speedometer 3.0 an upgraded browser benchmarking tool to optimize the performance of Web applications.*

In collaboration with major web browser engines, Blink/V8, Gecko/SpiderMonkey, and WebKit/JavaScriptCore, we’re excited to release [Speedometer 3.0](https://browserbench.org/Speedometer3.0/). Benchmarks, like Speedometer, are tools that can help browser vendors find opportunities to improve performance. Ideally, they simulate functionality that users encounter on typical websites, to ensure browsers can optimize areas that are beneficial to users.

Let’s dig into the new changes in Speedometer 3.0.

### **Applying a multi-stakeholder governance model**

Since its initial release in [2014](https://webkit.org/blog/3395/speedometer-benchmark-for-web-app-responsiveness/) by the WebKit team, browser vendors have successfully used Speedometer to optimize their engines and improve user experiences on the web. Speedometer 2.0, a result of a collaboration between Apple and Chrome, followed in [2018](https://webkit.org/blog/8063/speedometer-2-0-a-benchmark-for-modern-web-app-responsiveness/), and it included an updated set of workloads that were more representative of the modern web at that time.

The web has changed a lot since 2018, and so has Speedometer in its latest release, Speedometer 3. This work has been based on a joint [multi-stakeholder governance model](https://github.com/WebKit/Speedometer/blob/main/Governance.md) to share work, and build a collaborative understanding of performance on the web to help drive browser performance in ways that help users. The goal of this collaborative project is to create a shared understanding of web performance so that improvements can be made to enhance the user experience. Together, we were able to to improve how Speedometer captures and calculates scores, show more detailed results and introduce an even wider variety of workloads. This cross-browser collaboration introduced more diverse perspectives that enabled clearer insights into a broader set of web users and workflows, ensuring the newest version of Speedometer will help make the web better for everyone, regardless of which browser they use.

### **Why is building workloads challenging?**

Building a reliable benchmark with representative tests and workloads is challenging enough. That task becomes even more challenging if it will be used as a tool to guide optimization of browser engines over multiple years. To develop the Speedometer 3 benchmark, the [Chrome Aurora](https://developer.chrome.com/aurora) team, together with colleagues from other participating browser vendors, were tasked with finding new workloads that accurately reflect what users experience across the vast, diverse and eclectic web of 2024 and beyond.

A few tests and workloads can’t simulate the entire web, but while building Speedometer 3 we have established some criteria for selecting ones that are critical to user’s experience. We are now closer to a representative benchmark than ever before. Let’s take a look at how Speedometer workloads evolved

### **How did the workloads change?**

Since the goal is to use workloads that are representative of the web today, we needed to take a look at the previous workloads used in Speedometer and determine what changes were necessary. We needed to decide which frameworks are still relevant, which apps needed updating and what types of work we didn’t capture in previous versions. In Speedometer 2, all workloads were variations of a todo app implemented in different JS frameworks. We found that, as the web evolved over the past six years, we missed out on various JavaScript and Browser APIs that became popular, and apps tend to be much larger and more complicated than before. As a result, we made changes to the list of frameworks we included and we added a wider variety of workloads that cover a broader range of APIs and features.

### **Frameworks**

To determine which frameworks to include, we used data from [HTTP Archive](https://httparchive.org/) and discussed inclusion with all browser vendors to ensure we cover a good range of implementations. For the initial evaluation, we took a snapshot of the HTTP Archive from March 2023 to determine the top JavaScript UI frameworks currently used to build complex web apps.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhNL-3EGN3NyWERFEqb-GnA5UnYi_lDkyp1siFYN5X0qj6qAQWpMcwrC7_3Q0PQPeQCsbQf06FDp6e_RaNB-U6nvnf1JxljO1nUeZxSSAoqmyu2-9VNGP1QjNx6krI8W7EhdmDHyg8_kvzPm7Vf0Xjo1uPKl84R-mrDwXqbY1xf0EkMSHvtu2mcMwGCgxZ7/s16000/1Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_v2_Pages%20vs.%20Framework.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhNL-3EGN3NyWERFEqb-GnA5UnYi_lDkyp1siFYN5X0qj6qAQWpMcwrC7_3Q0PQPeQCsbQf06FDp6e_RaNB-U6nvnf1JxljO1nUeZxSSAoqmyu2-9VNGP1QjNx6krI8W7EhdmDHyg8_kvzPm7Vf0Xjo1uPKl84R-mrDwXqbY1xf0EkMSHvtu2mcMwGCgxZ7/s1932/1Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_v2_Pages%20vs.%20Framework.png)

  

Another approach is to determine inclusion based on popularity with developers: Do we need to include frameworks that have “momentum”, where a framework's current usage in production might be low, but we anticipate growth in adoption? This is somewhat hard to determine and might not be the ideal sole indicator for inclusion. One data point to evaluate momentum might be monthly NPM downloads of frameworks.

Here are the same 15 frameworks NPM downloads for March 2023:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhh9SdoPfDPz-wjCUTknvTaTq4D3pRTUDocU7BoUF-y8iePqktwFxZXUgkAkeWF4gG8kJIIXSTJL_-ugHzrW8LnsyFdlCCEz_MleUtADMnyhU6Nlztk_RPw2J9t7dWTtzIad2eB3U9IGOMXMyb-QB4j_26bmL77oUIThz3Otp5FBSPXmn_rG8bumjBpuTj1/s16000/2Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_Downloads%20vs.%20Framework.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhh9SdoPfDPz-wjCUTknvTaTq4D3pRTUDocU7BoUF-y8iePqktwFxZXUgkAkeWF4gG8kJIIXSTJL_-ugHzrW8LnsyFdlCCEz_MleUtADMnyhU6Nlztk_RPw2J9t7dWTtzIad2eB3U9IGOMXMyb-QB4j_26bmL77oUIThz3Otp5FBSPXmn_rG8bumjBpuTj1/s1932/2Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_Downloads%20vs.%20Framework.png)

  

With both data points on hand, we decided on a list that we felt gives us a good representation of frameworks. We kept the list small to allow space for brand new types of workloads, instead of just todo apps. We also selected commonly used versions for each framework, based on the current usage.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjWIjTao8HfxmLG3VNzDgwfcu4tHvdY1-Yu1CZxqnmHliA8LjkN4DbQy0uZDeSsdh11c7T53rQruwMoDyfqqcIgXgraNmmZ2rCjDJVCgbm0K4EP087sbjIb2utmxI8xN1OiJ7XG4L7NTYFdcg_DL2S_-kqU5Om46C6vX5dzvXiM8Kw-LJX247jB05iNZprj/s16000/3Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_Commonly%20Used%20Versions.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjWIjTao8HfxmLG3VNzDgwfcu4tHvdY1-Yu1CZxqnmHliA8LjkN4DbQy0uZDeSsdh11c7T53rQruwMoDyfqqcIgXgraNmmZ2rCjDJVCgbm0K4EP087sbjIb2utmxI8xN1OiJ7XG4L7NTYFdcg_DL2S_-kqU5Om46C6vX5dzvXiM8Kw-LJX247jB05iNZprj/s1932/3Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_Commonly%20Used%20Versions.png)

  

In addition, we updated the previous JavaScript implementations and included a new web-component based version, implemented with vanilla JavaScript.

### **More Workloads**

A simple Todo-list only tests a subset of functionality. For example: how well do browsers handle complicated flexbox and grid layouts? How can we capture SVG and canvas rendering and how can we include more realistic scenarios that happen on a website?

We collected and categorized areas of interest into DOM, layout, API and patterns, to be able to match them to potential workloads that would allow us to test these areas. In addition we collected user journeys that included the different categories of interest: editing text, rendering charts, navigating a site, and so on.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhvvQUbw7sWXJeFdASbV66Nn0mJxLkJtevbcCoy1UhZ9IRQj8tkHg657V31yKBiPd8T71ArAQmSedl9NeoqczYvv49MciBUuyfSg5-zyIOIrae807_5N3hzemRyQuTTHYsTiGZ7qV4ARPrQEO7vWIm9-R3kCaKpQcwRsxYr3NkqProgY-8mSe5PjHUNbSf-/s16000/4Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_More%20Workloads.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhvvQUbw7sWXJeFdASbV66Nn0mJxLkJtevbcCoy1UhZ9IRQj8tkHg657V31yKBiPd8T71ArAQmSedl9NeoqczYvv49MciBUuyfSg5-zyIOIrae807_5N3hzemRyQuTTHYsTiGZ7qV4ARPrQEO7vWIm9-R3kCaKpQcwRsxYr3NkqProgY-8mSe5PjHUNbSf-/s1932/4Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_More%20Workloads.png)

  

There are many more areas that we weren’t able to include, but the final list of workloads presents a larger variety and we hope that future versions of Speedometer will build upon the current list.

### **Validation**

The Chrome Aurora team worked with the [Chrome V8 team](https://v8.dev/) to validate our assumptions above. In Chrome, we can use [runtime-call-stats](https://v8.dev/docs/rcs) to measure time spent in each web API (and additionally many internal components). This allows us to get an insight into how dominant certain APIs are.

If we look at Speedometer 2.1 we see that a disproportionate amount of benchmark time is spent in innerHTML.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiyW_hT0-7IEsnU0vMSGYepKt3W9atMq1rHRw0hKyQ_8zLozWyM0yILERSynI5j5F4rWM5ZKRaWPgaSanJxzwBZD0aqt_wye9p1yQmOzZaOF7cEXRPeMLTF-MhWJorfg-Q9QEAkP6Y1DKVM5AFUieQoP94Y18TyAWb8g-a3sdz_Tgxk-DMMqs_O7CwI03HA/s16000/5Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_v2_Speedometer%202.1%20Chrome%20API%20Usage.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiyW_hT0-7IEsnU0vMSGYepKt3W9atMq1rHRw0hKyQ_8zLozWyM0yILERSynI5j5F4rWM5ZKRaWPgaSanJxzwBZD0aqt_wye9p1yQmOzZaOF7cEXRPeMLTF-MhWJorfg-Q9QEAkP6Y1DKVM5AFUieQoP94Y18TyAWb8g-a3sdz_Tgxk-DMMqs_O7CwI03HA/s1932/5Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_v2_Speedometer%202.1%20Chrome%20API%20Usage.png)

  

While [innerHTML](http://go/mdn/API/Element/innerHTML) is an important web API, it's overrepresented in Speedometer 2.1. Doing the same analysis on the new version 3.0 yields a slightly different picture:

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgEdKNUJzhrWhWY8AHHiZYGfTLsF-crQZKcvAGhD_RtAfD0fsRDGuufFew8kCUccNrhcyF17K_cEvyR38nFx2_CgS9ZIE2Z2afe4DXCg6Rou8n_J3iY8Jq0A8lUo0TlzAG5AOmstNzaraw_47S8r_TzS9ZYX4t1Mqf5Wpe3QRissuDEhabmzk_q_7lEmVE3/s16000/6Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_Speedometer%203.0%20Chrome%20API%20Usage.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgEdKNUJzhrWhWY8AHHiZYGfTLsF-crQZKcvAGhD_RtAfD0fsRDGuufFew8kCUccNrhcyF17K_cEvyR38nFx2_CgS9ZIE2Z2afe4DXCg6Rou8n_J3iY8Jq0A8lUo0TlzAG5AOmstNzaraw_47S8r_TzS9ZYX4t1Mqf5Wpe3QRissuDEhabmzk_q_7lEmVE3/s1932/6Chrome_Fast%20&%20Curious_Blog%20Assets_Speedometer%203.0_Speedometer%203.0%20Chrome%20API%20Usage.png)

  

We can see that innerHTML is still present, but its overall contribution shrunk from roughly 14% down to 4.5%. As a result, we get a better distribution that favors more DOM APIs to be optimized. We can also see that a few Canvas APIs have moved into this list, thanks to the new workloads in v3.0.

While we will never be able to perfectly represent the whole web in a fast-running and stable benchmark, it is clear that Speedometer 3.0 is a giant step in the right direction.

Ultimately, we ended up with the following list of workloads presented in the next few sections.

### **What workloads are included?**

***TodoMVC***

Many developers might recognize the [TodoMVC app](https://todomvc.com/). It’s a popular resource for learning and offers a wide range of TodoMVC implementations with different frameworks.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi3uqFby4YGbOdvIEo3mgb6EjFO4q9OtRNagMiDOEcTzVFyzrMeJCKoab-U4fyKVQr7rfbfTzTgCmbNxgy84pl3-bfvsfVmC6mqBYcxNB739yNTlYORwySDsKmNRIjdjwivLcpI6iG6CzGOz7x2Gy0gq1LIgRCgIJi2neq1nQWfo0G07plVTRF3E6nGs_2q/s16000/1TodoMVC.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi3uqFby4YGbOdvIEo3mgb6EjFO4q9OtRNagMiDOEcTzVFyzrMeJCKoab-U4fyKVQr7rfbfTzTgCmbNxgy84pl3-bfvsfVmC6mqBYcxNB739yNTlYORwySDsKmNRIjdjwivLcpI6iG6CzGOz7x2Gy0gq1LIgRCgIJi2neq1nQWfo0G07plVTRF3E6nGs_2q/s842/1TodoMVC.png)

  

TodoMVC is a to-do application that allows a user to keep track of tasks. The user can enter a new task, update an existing one, mark a task as completed, or delete it. In addition to the basic CRUD operations, the TodoMVC app has some added functionality: filters are available to change the view to “all”, “active” or “completed” tasks and a status text displays the number of active tasks to complete.

In Speedometer, we introduced a local data source for todo items, which we use in our tests to populate the todo apps. This gave us the opportunity to test a larger character set with different languages.

The tests for these apps are all similar and are relatable to typical user journeys with a todo app:

1. Add a task
2. Mark task as complete
3. Delete task
4. Repeat steps 1-3 a set amount of times

These tests seem simple, but it lets us benchmark DOM manipulations. Having a variety of framework implementations also cover several different ways how this can be done.

***Complex DOM / TodoMVC***

The complex DOM workloads embed various TodoMVC implementations in a static UI shell that mimics a complex web page. The idea is to capture the performance impact on executing seemingly isolated actions (e.g. adding/deleting todo items) in the context of a complex website. Small performance hits that aren’t obvious in an isolated TodoMVC workload are amplified in a larger application and therefore capture more real-world impact.

The tests are similar to the TodoMVC tests, executed in the complex DOM & CSSOM environment.

This introduces an additional layer of complexity that browsers have to be able to handle effortlessly.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEigyFShRHZAVX8SzN0eRf1XyOPAwT1563BKuuzaOYSlG8-rVaeSqGj88DFM3bsiJmveZ5z-XB-2jaZp8Exz6NTvf1wQbN1vmouCnSbMV8QtXbWpsbbAhEFQOk0zuhTxOkUfbcDadVy6nbQ7HhjgsmQEghoO_v3v8FMnsCB7ZWWzk8YsZXeXZbD8zWbItd33/s16000/2Complex%20DOM%20%20TodoMVC.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEigyFShRHZAVX8SzN0eRf1XyOPAwT1563BKuuzaOYSlG8-rVaeSqGj88DFM3bsiJmveZ5z-XB-2jaZp8Exz6NTvf1wQbN1vmouCnSbMV8QtXbWpsbbAhEFQOk0zuhTxOkUfbcDadVy6nbQ7HhjgsmQEghoO_v3v8FMnsCB7ZWWzk8YsZXeXZbD8zWbItd33/s822/2Complex%20DOM%20%20TodoMVC.png)

  

***Single-page-applications (News Site)***

Single-page-applications (SPAs) are widely used on the web for streaming, gaming, social media and pretty much anything you can imagine. A SPA lets us capture navigating between pages and interacting with an app. We chose a news site to represent a SPA, since it allows us to capture the main areas of interest in a deterministic way. An important factor was that we want to ensure we are using static local data and that the app doesn’t rely on network requests to present this data to the user.

Two implementations are included: one built with Next.js and the other with Nuxt. This gave us the opportunity to represent applications built with meta frameworks, with the caveat that we needed to ensure to use static outputs.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgeu13O9BevycHTsDVrYPsWvaM3lJEKPPUz9Ket2PmQLQE3pOpYTE_YNv85egpLFAqW3_5f0c-fHclB283uH7Xh8bTJsxMeFu9ArDW892iBSFNVTrVhqKLw4JN23XrW-zH8BnIdvND1SbC9am0kF16t4DjPuSOoOoF5qqprsyFHiMNOINqpNWZTXsQWtQAE/s16000/3Single-page-applications%20(News%20Site).png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEgeu13O9BevycHTsDVrYPsWvaM3lJEKPPUz9Ket2PmQLQE3pOpYTE_YNv85egpLFAqW3_5f0c-fHclB283uH7Xh8bTJsxMeFu9ArDW892iBSFNVTrVhqKLw4JN23XrW-zH8BnIdvND1SbC9am0kF16t4DjPuSOoOoF5qqprsyFHiMNOINqpNWZTXsQWtQAE/s826/3Single-page-applications%20(News%20Site).png)

  

Tests for the news site mimic a typical user journey, by selecting a menu item and navigating to another section of the site.

1. Click on ‘More’ toggle of the navigation
2. Click on a navigation button
3. Repeat steps 1 and 2 a set amount of times

These tests let us evaluate how well a browser can handle large DOM and CSSOM changes, by changing a large amount of data that needs to be displayed when navigating to a different page.

***Charting Apps & Dashboards***

Charting apps allow us to test SVG and canvas rendering by displaying charts in various workloads.

These apps represent popular sites that display financial information, stock charts or dashboards.

Both SVG rendering and the use of the canvas api weren’t represented in previous releases of Speedometer.

**Observable Plot** displays a stacked bar chart, as well as a dotted chart. It is based on D3, which is a JavaScript library for visualizing tabular data and outputs SVG elements. It loops through a big dataset to build the source data that D3 needs, using map, filter and flatMap methods. As a result this exercises creation and copying of objects and arrays.

**Chart.js** is a JavaScript charting library. The included workload displays a scatter graph with the canvas api, both with some transparency and with full opacity. This uses the same data as the previous workload, but with a different preparation phase. In this case it makes a heavy use of trigonometry to compute distances between airports.

**React Stockcharts** displays a dashboard for stocks. It is based on D3 for all computation, but outputs SVG directly using React.

**Webkit Perf-Dashboard** is an application used to track various performance metrics of WebKit. The dashboard uses canvas drawing and web components for its ui.

These workloads test DOM manipulation with SVG or canvas by interacting with charts. For example here are the interactions of the Observable Plot workload:

1. Prepare data: compute the input datasets to output structures that D3 understands.
2. Add stacked chart: this draws a chart using SVG elements.
3. Change input slider to change the computation parameters.
4. Repeat steps 1 and 2
5. Reset: this clears the view
6. Add dotted chart: this draws another type of graph (dots instead of bars) to exercise different drawing primitives. This also uses a power scale.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi1QH4eW4eb6BhbRSvNOkbrq9HXwSWc53aNbMKuxv5I5Sw2LzMiN5BMVqAwo6GCag4VGThAy9jifHBmc2yVRDxwNFuJo6C-jymDoTfpZqzcmFNOrtWUsHfbUxeQ0cjixXh7WRajjHdj-V_dK-FrQxCEEV5XXDzgKp7Q3xiHrTc9LJcgDaO9Ryg4_KnsYKhN/s16000/4Webkit%20Perf-Dashboard_1.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEi1QH4eW4eb6BhbRSvNOkbrq9HXwSWc53aNbMKuxv5I5Sw2LzMiN5BMVqAwo6GCag4VGThAy9jifHBmc2yVRDxwNFuJo6C-jymDoTfpZqzcmFNOrtWUsHfbUxeQ0cjixXh7WRajjHdj-V_dK-FrQxCEEV5XXDzgKp7Q3xiHrTc9LJcgDaO9Ryg4_KnsYKhN/s846/4Webkit%20Perf-Dashboard_1.png)

  

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg7BWgJu6HvFqDwADBq9Q0GblZFHIJpp052nYZM0CgRfQbbsAp-VTN8Xpy1o1XbYhIqUKoGg4uELeo6Un2NHFul2qaAzL99Y7vxJqASK8uMXDD8GyX2jIFIAiBl36suwaHO5hGUmvxQMt09mX38Oh5R8hOXckFneevSpQlChMu5qQmcUiKIqoaAQiCxNjrB/s16000/5Webkit%20Perf-Dashboard_2.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEg7BWgJu6HvFqDwADBq9Q0GblZFHIJpp052nYZM0CgRfQbbsAp-VTN8Xpy1o1XbYhIqUKoGg4uELeo6Un2NHFul2qaAzL99Y7vxJqASK8uMXDD8GyX2jIFIAiBl36suwaHO5hGUmvxQMt09mX38Oh5R8hOXckFneevSpQlChMu5qQmcUiKIqoaAQiCxNjrB/s822/5Webkit%20Perf-Dashboard_2.png)

  

***Code Editors***

Editors, for example WYSIWYG text and code editors, let us focus on editing live text and capturing form interactions. Typical scenarios are writing an email, logging into a website or filling out an online form. Although there is some form interaction present in the TodoMVC apps, the editor workloads use a large data set, which lets us evaluate performance more accurately.

[![](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiHb9rJqJXZ95LXsDjo8Zd1l2TciE1uFZ5eolDJf3euB5P7C8KwJ27vB-xlCic8R7CHNy7Qxuea9zuCsqbdJ4k6safN5Z7oA6KadxbzYEus6TRmVV0cHZLcJedupQb6R-0DB4YpMagfvjviPhxGfWAIDmxzJ7jBXGzjALxeMmxuEoTACaNMIrDqEnoAMwXA/s16000/6Code%20Editors.png)](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiHb9rJqJXZ95LXsDjo8Zd1l2TciE1uFZ5eolDJf3euB5P7C8KwJ27vB-xlCic8R7CHNy7Qxuea9zuCsqbdJ4k6safN5Z7oA6KadxbzYEus6TRmVV0cHZLcJedupQb6R-0DB4YpMagfvjviPhxGfWAIDmxzJ7jBXGzjALxeMmxuEoTACaNMIrDqEnoAMwXA/s846/6Code%20Editors.png)

  

**Codemirror** is a code editor that implements a text input field with support for many editing features. Several languages and frameworks are available and for this workload we used the JavaScript library from Codemirror.

**Tiptap** Editor is a headless, framework-agnostic rich text editor that's customizable and extendable. This workload used Tiptap as its basis and added a simple ui to interact with.

Both apps test DOM insertion and manipulation of a large amount of data in the following way:

1. Create an editable element.
2. Insert a long text.: Codemirror uses the development bundle of React, whileTipTap loads an excerpt of Proust’s Du Côté de Chez Swann.
3. Highlight text: Codemirror turns on syntax highlighting, while TipTap sets all the text to bold.

### **Parting words**

Being able to collaborate with all major browser vendors and having all of us contribute to workloads has been a unique experience and we are looking forward to continuing to collaborate in the browser benchmarking space.

Don’t forget to check out the new release of Speedometer and test it out in your favorite browser, dig into the results, check out our repo and feel free to open issues with any improvements or ideas for workloads you would like to see included in the next version. We are aiming for a more frequent release schedule in the future and if you are a framework author and want to contribute, feel free to file an issue on our [Github](https://github.com/WebKit/Speedometer/issues) to start the discussion.

*Posted by Thorsten Kober, Chrome Aurora*