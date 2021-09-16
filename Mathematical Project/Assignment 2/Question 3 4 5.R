##------------------------------------------------------------------------##
## Assignment Question 3
##------------------------------------------------------------------------##

#Make Sure you have changed the working directory location for reading excel file.
setwd("C:\\Users\\user\\Desktop\\Drive\\Mathematical and Statistical Software\\Assignment\\Assignment 2")

library(readxl)
data <- read_excel("Question 345.xlsx", sheet = "Question 3")


#to count number of customer
cont_table <- table(data$Area, data$Status)
cont_table
# Output :
#   Excellent Poor
# A       118   82
# B       160   90

# H0 : There is no association between percentage of customers who think the food and service 
#      are excellent and restaurant in different area of a city. 
# H1 : There is an association between percentage of customers who think the food and service 
#      are excellent and restaurant in different area of a city.

summary(cont_table)
# Output : 
# Number of cases in table: 450 
# Number of factors: 2 
# Test for independence of all factors:
# Chisq = 1.1764, df = 1, p-value = 0.2781

chisq.test(data$Area, data$Status, correct = FALSE)
# Output
# Pearson's Chi-squared test
# data:  data$Area and data$Status
# X-squared = 1.1764 , df = 1, p-value = 0.2781

chisq.test(data$Area, data$Status, correct = TRUE)
# Output
# Pearson's Chi-squared test with Yates' continuity correction
# data:  data$Area and data$Status
# X-squared = 0.97416, df = 1, p-value = 0.3236

rm(list = ls())

##------------------------------------------------------------------------##
## Assignment Question 4
##------------------------------------------------------------------------##

data <- read_excel("Question 345.xlsx", sheet = "Question 4")
head(data, n = 5)

# H0 : var1 = var2
# H1 : var1 != var2

var.test(data$`Machine A`,data$`Machine B`)
# Output :
# 	F test to compare two variances

# data:  data$`Machine A` and data$`Machine B`
# F = 0.81294, num df = 9, denom df = 9, p-value = 0.7627
# alternative hypothesis: true ratio of variances is not equal to 1
# 95 percent confidence interval:
#  0.2019234 3.2729012
# sample estimates:
# ratio of variances 
#          0.8129424 

# H0 : mu1 <= mu2
# H1 : mu1 >  mu2

t.test(data$`Machine A`, data$`Machine B`, alternative = "g", 
       var.equal = TRUE)
# Output :
# Two Sample t-test

# data:  data$`Machine A` and data$`Machine B`
# t = -0.21255, df = 18, p-value = 0.583
# alternative hypothesis: true difference in means is greater than 0
# 95 percent confidence interval:
#  -2.747563       Inf
# sample estimates:
# mean of x mean of y 
#      22.6      22.9 

rm(list = ls())

##------------------------------------------------------------------------##
## Assignment Question 5
##------------------------------------------------------------------------##

data <- read_excel("Question 345.xlsx", sheet = "Question 5")

#to count number of customer
cont_table <- table(data$Season, data$Zone)
cont_table
# Output :
#                  A   B   C
# Off-Peak Hours  50  45 105
# Peak Hours     150 255 395

summary(cont_table)
# Output :
# Number of cases in table: 1000 
# Number of factors: 2 
# Test for independence of all factors:
# Chisq = 8.125, df = 2, p-value = 0.01721

chisq.test(cont_table)
# Output :
# Pearson's Chi-squared test

# data:  cont_table
# X-squared = 8.125, df = 2, p-value = 0.01721

chisq.test(data$Season, data$Zone)
# Output :
# Pearson's Chi-squared test

# data:  cont_table
# X-squared = 8.125, df = 2, p-value = 0.01721

rm(list = ls())
