﻿using RESTFull.API.dto;
using RESTFull.Domain;
using RESTFull.Service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.mapper
{
    public class ConferenceMapper
    {
        public ConferenceMapper()
        {
        }

        public Conference map(ConferenceCreateDto createDto)
        {
            Conference result = new Conference();

            result.title = createDto.title;
            result.status = createDto.status;
            result.startDate = createDto.startDate;
            result.endDate = createDto.endDate;
            result.description = createDto.description;
            result.location = createDto.location;

            return result;
        }
        public Conference map(ConferenceUpdateDto updateDto)
        {
            Conference result = new Conference();

            result.Id = updateDto.id;
            result.title = updateDto.title;
            result.status = updateDto.status;
            result.startDate = updateDto.startDate;
            result.endDate = updateDto.endDate;
            result.description = updateDto.description;
            result.location = updateDto.location;


            return result;
        }
        public ConferencePublicDto map(Conference conference)
        {
            ConferencePublicDto result = new ConferencePublicDto();

            result.id = conference.Id.ToString();
            result.title = conference.title;
            result.status = conference.status;
            result.startDate = conference.startDate;
            result.endDate = conference.endDate;
            result.description = conference.description;
            result.location = conference.location;
            result.sections = conference.sections.Aggregate(new List<SectionNoRefDto>(),
                (total, c) => { total.Add(SectionMapper.mapToNRDto(c)); return total; });
            result.participants = conference.participants.Aggregate(new List<ParticipantNoRefDto>(),
                (total, c) => { total.Add(ParticipantMapper.mapToNRDto(c)); return total; });

            return result;
        }
        public static ConferenceNoRefDto mapToNRDto(Conference conference)
        {

            ConferenceNoRefDto result = new ConferenceNoRefDto();

            result.id = conference.Id.ToString();
            result.title = conference.title;
            result.status = conference.status;
            result.startDate = conference.startDate;
            result.endDate = conference.endDate;
            result.description = conference.description;
            result.location = conference.location;
            result.sections = conference.sections.Aggregate(new List<String>(),
                (total, c) =>
                {
                    total.Add(c.Id.ToString());
                    return total;
                });
            result.participants = conference.participants.Aggregate(new List<String>(),
                (total, c) =>
                {
                    total.Add(c.Id.ToString());
                    return total;
                });

            return result;
        }
    }
        
}
