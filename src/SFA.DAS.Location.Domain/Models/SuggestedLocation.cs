﻿using SFA.DAS.Location.Domain.ImportTypes;

namespace SFA.DAS.Location.Domain.Models
{
    public class SuggestedLocation
    {
        public string CountyName { get; set; }
        public string LocationName { get; set; }
        public string LocalAuthorityName { get; set; }
        public string Postcode { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string DistrictName { get; set; }

        public static implicit operator SuggestedLocation(PostcodesLocationApiItem source)
        {
            return new SuggestedLocation
            {
                // does the below return an authority name?

                Lat = source.Lat,
                Long = source.Long,
                Postcode = source.Postcode,
                DistrictName = source.AdminDistrict
            };
        }

        public static implicit operator SuggestedLocation(Domain.Entities.Location source)
        {
            return new SuggestedLocation
            {
                Lat = source.Lat,
                Long = source.Long,
                CountyName = source.CountyName,
                LocationName = source.LocationName,
                LocalAuthorityName = source.LocalAuthorityName,
            };
        }
    }

}
